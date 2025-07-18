using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Snake : Form
    {
        private List<Point> snake = new List<Point>();
        private Point food;
        private int gridSize = 20;
        private string direction = "right";
        private Random rnd = new Random();
        private int score = 0;
        int meleMangiate = 0;
        bool IsMelaOro = false;
        public Snake()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            snake.Clear();
            direction = "right";
            meleMangiate = 0;
            IsMelaOro = false;
            score = 0;
            snake.Add(new Point(5, 5));
            GenerateFood();
            timer1.Start();
        }

        private void GenerateFood()
        {
            Random rnd = new Random();
            Point newFood;
            int maxX = this.ClientSize.Width / gridSize;
            int maxY = this.ClientSize.Height / gridSize;
            do
            {
                newFood = new Point(rnd.Next(maxX), rnd.Next(maxY));
            } while (snake.Contains(newFood));
            food = newFood;
            meleMangiate++;
            IsMelaOro = meleMangiate % 5 == 0;
        }

        private bool Collision(Point head)
        {
            int maxX = this.ClientSize.Width / gridSize;
            int maxY = this.ClientSize.Height / gridSize;

            // Fuori dai bordi
            if (head.X < 0 || head.Y < 0 || head.X >= maxX || head.Y >= maxY)
                return true;

            // Tocca se stesso
            for (int i = 1; i < snake.Count; i++)
                if (snake[i] == head)
                    return true;

            return false;
        }
        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (direction != "down") direction = "up";
                    break;
                case Keys.Down:
                    if (direction != "up") direction = "down";
                    break;
                case Keys.Left:
                    if (direction != "right") direction = "left";
                    break;
                case Keys.Right:
                    if (direction != "left") direction = "right";
                    break;
            }
        }

        private void Snake_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush foodBrush = IsMelaOro ? Brushes.Gold : Brushes.Red;
            // Cibo
            g.FillRectangle(foodBrush, food.X * gridSize, food.Y * gridSize, gridSize, gridSize);

            // Serpente
            for (int i = 0; i < snake.Count; i++)
            {
                Brush brush = i == 0 ? Brushes.Lime : Brushes.Green;
                g.FillRectangle(brush, snake[i].X * gridSize, snake[i].Y * gridSize, gridSize, gridSize);
            }

            // Punteggio
            g.DrawString($"Score: {score}", new Font("Arial", 12, FontStyle.Bold), Brushes.White, 10, 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point head = snake[0];
            Point newHead = head;

            switch (direction)
            {
                case "up": newHead.Y--; break;
                case "down": newHead.Y++; break;
                case "left": newHead.X--; break;
                case "right": newHead.X++; break;
            }

            if (Collision(newHead))
            {
                timer1.Stop();
                string gioco = "Snake";
                string utente = UtenteC.NomeU;
                int punteggioAttuale = GestionePunteggi.OttieniPunteggio(gioco, utente);
                if (!(punteggioAttuale > score))
                {
                    int nuovoPunteggio = score;
                    GestionePunteggi.AggiornaPunteggio(gioco, utente, nuovoPunteggio);
                }

                DialogResult risultato = MessageBox.Show($"Game Over! Punteggio: {score}" +
                                                          "\n" + "Vuoi rigiocare?", "Game over", MessageBoxButtons.YesNo);
                if (risultato == DialogResult.Yes)
                {
                    StartGame();
                    timer1.Interval = 100;
                    return;
                }
                else
                {
                    Close();
                }
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                if (!IsMelaOro)
                {
                    score += 10;
                }
                else
                {
                    score += 20;
                    if (timer1.Interval > 10)
                    {
                        timer1.Interval -= 10;
                    }

                }
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            this.Invalidate();
        }

        private void Snake_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire da Snake?",
                                                      "Torna al menu",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Stop);
            if (risultato == DialogResult.Yes)
            {
                new MenuLog().Show();
            }
            else
            {
                var posizione = this.Location;
                var nuovoForm = new Snake();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartGame();
            BtnStart.Visible = false;
            LblTitolo.Visible = false;
            BtnClassifica.Visible = false;
        }

        private void BtnClassifica_Click(object sender, EventArgs e)
        {
            new Classifica("Snake").Show();
        }
    }
}
