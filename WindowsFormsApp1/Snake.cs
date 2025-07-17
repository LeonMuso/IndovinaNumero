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
        public Snake()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            snake.Clear();
            direction = "right";
            score = 0;
            snake.Add(new Point(5, 5));
            GenerateFood();
            timer1.Start();
        }

        private void GenerateFood()
        {
            int maxX = this.ClientSize.Width / gridSize;
            int maxY = this.ClientSize.Height / gridSize;
            food = new Point(rnd.Next(maxX), rnd.Next(maxY));
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

            // Cibo
            g.FillRectangle(Brushes.Red, food.X * gridSize, food.Y * gridSize, gridSize, gridSize);

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
                MessageBox.Show($"Game Over! Punteggio: {score}");
                StartGame();
                return;
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                score += 10;
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
            DialogResult risultato = MessageBox.Show($"Vuoi uscire da indovina il numero?",
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
    }
}
