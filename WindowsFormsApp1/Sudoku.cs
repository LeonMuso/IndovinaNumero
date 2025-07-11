using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Sudoku : Form
    {
        private TableLayoutPanel griglia;
        private TextBox[,] celle = new TextBox[9, 9];
        private int[,] schemaCompleto;
        private Random rand = new Random();

        private Timer timerGioco;
        private int secondiTrascorsi = 0;
        private Button btnSalvaPunteggio;
        private readonly string pathPunteggi = "Punteggi.json";
        private Label lblTimer;

        public Sudoku()
        {
            InitializeComponent();
            InizializzaInterfaccia();
            GeneraNuovaPartita("facile");
        }

        private void InizializzaInterfaccia()
        {
            this.Text = "Sudoku";
            this.Size = new Size(520, 600);


            ComboBox cmbDifficolta = new ComboBox
            {
                Location = new Point(20, 10),
                Width = 100,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "cmbDifficolta"
            };
            cmbDifficolta.Items.AddRange(new[] { "facile", "medio", "difficile" });
            cmbDifficolta.SelectedIndex = 0;
            this.Controls.Add(cmbDifficolta);


            Button btnNuova = new Button
            {
                Text = "Nuova Partita",
                Location = new Point(140, 10),
                Width = 120
            };
            this.Controls.Add(btnNuova);


            btnSalvaPunteggio = new Button
            {
                Text = "Salva Punteggio",
                Location = new Point(280, 10),
                Width = 120
            };
            this.Controls.Add(btnSalvaPunteggio);


            lblTimer = new Label
            {
                Text = "Tempo: 0s",
                Location = new Point(410, 15),
                Width = 100
            };
            this.Controls.Add(lblTimer);


            griglia = new TableLayoutPanel
            {
                RowCount = 9,
                ColumnCount = 9,
                Location = new Point(20, 50),
                Size = new Size(450, 450),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            for (int i = 0; i < 9; i++)
            {
                griglia.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.11f));
                griglia.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11f));
            }
            this.Controls.Add(griglia);


            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    TextBox txt = new TextBox
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Segoe UI", 14),
                        MaxLength = 1,
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.White
                    };
                    celle[r, c] = txt;


                    int top = (r % 3 == 0) ? 3 : 1;
                    int left = (c % 3 == 0) ? 3 : 1;
                    int bottom = (r == 8) ? 3 : 1;
                    int right = (c == 8) ? 3 : 1;


                    Panel borderPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.Black,
                        Padding = new Padding(left, top, right, bottom)
                    };


                    Panel innerPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White
                    };

                    innerPanel.Controls.Add(txt);
                    borderPanel.Controls.Add(innerPanel);
                    griglia.Controls.Add(borderPanel, c, r);
                }
            }


            timerGioco = new Timer();
            timerGioco.Interval = 1000;
            timerGioco.Tick += (s, e) =>
            {
                secondiTrascorsi++;
                lblTimer.Text = $"Tempo: {secondiTrascorsi}s";
            };
            timerGioco.Start();


            btnNuova.Click += (s, e) =>
            {
                string difficolta = cmbDifficolta.SelectedItem.ToString();
                GeneraNuovaPartita(difficolta);
            };

            btnSalvaPunteggio.Click += (s, e) =>
            {
                int punteggio = CalcolaPunteggioConErrori();
                SalvaPunteggioSudoku("Sudoku", punteggio);
                MessageBox.Show($"Punteggio finale: {punteggio} punti\nTempo: {secondiTrascorsi} secondi", "Punteggio Salvato");
            };
        }

        private void GeneraNuovaPartita(string difficolta)
        {
            schemaCompleto = GeneraSudokuCompletato();
            int celleVuote = difficolta == "facile" ? 30 : difficolta == "medio" ? 45 : 55;

            int[,] schemaParziale = (int[,])schemaCompleto.Clone();
            int rimanenti = celleVuote;
            while (rimanenti > 0)
            {
                int r = rand.Next(9);
                int c = rand.Next(9);
                if (schemaParziale[r, c] != 0)
                {
                    schemaParziale[r, c] = 0;
                    rimanenti--;
                }
            }

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (schemaParziale[r, c] != 0)
                    {
                        celle[r, c].Text = schemaParziale[r, c].ToString();
                        celle[r, c].ReadOnly = true;
                        celle[r, c].BackColor = Color.LightGray;
                    }
                    else
                    {
                        celle[r, c].Text = "";
                        celle[r, c].ReadOnly = false;
                        celle[r, c].BackColor = Color.White;
                    }
                }
            }

            secondiTrascorsi = 0;
            timerGioco.Start();
        }

        private int[,] GeneraSudokuCompletato()
        {
            int[,] board = new int[9, 9];
            RisolviSudoku(board);
            return board;
        }

        private bool RisolviSudoku(int[,] board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r, c] == 0)
                    {
                        var numeri = Enumerable.Range(1, 9).OrderBy(x => rand.Next()).ToList();
                        foreach (int n in numeri)
                        {
                            if (Valido(board, r, c, n))
                            {
                                board[r, c] = n;
                                if (RisolviSudoku(board))
                                    return true;
                                board[r, c] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Valido(int[,] board, int r, int c, int val)
        {
            for (int i = 0; i < 9; i++)
                if (board[r, i] == val || board[i, c] == val)
                    return false;

            int inizioRiga = (r / 3) * 3;
            int inizioColonna = (c / 3) * 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[inizioRiga + i, inizioColonna + j] == val)
                        return false;

            return true;
        }

        private int CalcolaPunteggioConErrori()
        {
            int punti = 0;

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    var txt = celle[r, c];
                    string contenuto = txt.Text.Trim();

                    if (string.IsNullOrEmpty(contenuto)) continue;

                    if (int.TryParse(contenuto, out int valore))
                    {
                        if (valore == schemaCompleto[r, c])
                            punti += 1;
                        else
                            punti -= 2;
                    }
                }
            }

            int bonusTempo = 100 - (secondiTrascorsi / 30);
            if (bonusTempo < 0) bonusTempo = 0;

            punti += bonusTempo;
            return punti < 0 ? 0 : punti;
        }

        private void SalvaPunteggioSudoku(string gioco, int punti)
        {
            Dictionary<string, Dictionary<string, int>> dati = new Dictionary<string, Dictionary<string, int>>();

            if (File.Exists(pathPunteggi))
            {
                string jsonEsistente = File.ReadAllText(pathPunteggi);
                dati = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(jsonEsistente)
                       ?? new Dictionary<string, Dictionary<string, int>>();
            }

            if (!dati.ContainsKey(gioco))
                dati[gioco] = new Dictionary<string, int>();

            string utente = Environment.UserName;
            dati[gioco][utente] = punti;

            string json = JsonConvert.SerializeObject(dati, Formatting.Indented);
            File.WriteAllText(pathPunteggi, json);
        }
    }

}

