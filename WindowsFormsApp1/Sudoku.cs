using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace SudokuWinForms
{
    public partial class Sudoku : Form
    {
        private TextBox[,] celle = new TextBox[9, 9];
        private int[,] schemaCompleto;
        private TableLayoutPanel griglia;
        private Label lblErrori;
        private int errori = 0;
        private const int MaxErrori = 7;
        private Timer timerGioco;
        private int secondiTrascorsi = 0;
        private Label lblTimer;
        private string Utente = UtenteC.NomeU;
        private bool[,] erroriContati = new bool[9, 9];

        public Sudoku()
        {
            InitializeComponent();
            LblUtente.Text = UtenteC.NomeU;
            InizializzaInterfaccia();
            NuovaPartita(Difficolta.Facile);
        }

        private void InizializzaInterfaccia()
        {

            griglia = new TableLayoutPanel
            {
                RowCount = 9,
                ColumnCount = 9,
                Dock = DockStyle.Top,
                Size = new Size(450, 450),
                Location = new Point(20, 20)
            };

            for (int i = 0; i < 9; i++)
            {
                griglia.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1f));
                griglia.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1f));
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

            lblErrori = new Label
            {
                Text = "Errori: 0",
                Location = new Point(20, 480),
                Width = 150,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblErrori);

            lblTimer = new Label
            {
                Text = "Tempo: 0s",
                Location = new Point(200, 480),
                Width = 150,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblTimer);

            timerGioco = new Timer();
            timerGioco.Interval = 1000;
            timerGioco.Tick += (s, e) =>
            {
                secondiTrascorsi++;
                lblTimer.Text = $"Tempo: {secondiTrascorsi}s";
            };
            CbDiff.Items.AddRange(new[] { "Facile", "Medio", "Difficile" });
            CbDiff.SelectedIndex = 0;
        }

        private void NuovaPartita(Difficolta diff)
        {
            schemaCompleto = GeneraSchemaCompleto();
            int[,] schemaParziale = RimuoviCelle(schemaCompleto, diff);
            errori = 0;
            lblErrori.Text = "Errori: 0";
            secondiTrascorsi = 0;
            lblTimer.Text = "Tempo: 0s";
            timerGioco.Start();
            erroriContati = new bool[9, 9];

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    var txt = celle[r, c];
                    txt.TextChanged -= null;
                    txt.ForeColor = Color.Black;

                    if (schemaParziale[r, c] != 0)
                    {
                        txt.Text = schemaParziale[r, c].ToString();
                        txt.ReadOnly = true;
                        txt.ForeColor = Color.Black;
                    }
                    else
                    {
                        txt.Text = "";
                        txt.ReadOnly = false;
                        int rr = r, cc = c;
                        txt.TextChanged += (s, e) =>
                        {
                            if (txt.ReadOnly) return;

                            string valore = txt.Text.Trim();
                            if (valore.Length != 1 || !char.IsDigit(valore[0]) || valore == "0") return;

                            int inserito = int.Parse(valore);
                            if (inserito != schemaCompleto[rr, cc])
                            {
                                if (!erroriContati[rr, cc])
                                {
                                    errori++;
                                    erroriContati[rr, cc] = true;
                                    lblErrori.Text = $"Errori: {errori}";

                                }
                                txt.ForeColor = Color.Red;

                                if (errori >= MaxErrori)
                                {
                                    timerGioco.Stop();
                                    MessageBox.Show("Hai commesso 7 errori!\nHai perso la partita.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    DisabilitaGriglia();
                                }
                            }
                            else
                            {
                                txt.ForeColor = Color.Green;
                                if (CelleComplete())
                                {
                                    timerGioco.Stop();
                                    int punteggio = CalcolaPunteggio();
                                    MessageBox.Show($"Hai vinto!\nPunteggio: {punteggio}", "Vittoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    SalvaPunteggioNelJson(Utente, punteggio);
                                    DisabilitaGriglia();
                                }
                            }
                        };
                    }
                }
            }
        }

        private void DisabilitaGriglia()
        {
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    celle[r, c].ReadOnly = true;
        }

        private int[,] GeneraSchemaCompleto()
        {
            int[,] griglia = new int[9, 9];
            RiempieSchema(griglia, 0, 0);
            return griglia;
        }

        private bool RiempieSchema(int[,] griglia, int riga, int colonna)
        {
            if (riga == 9)
                return true;

            int nextRiga = (colonna == 8) ? riga + 1 : riga;
            int nextColonna = (colonna + 1) % 9;

            var numeri = Enumerable.Range(1, 9).OrderBy(n => Guid.NewGuid()).ToList();

            foreach (int numero in numeri)
            {
                if (PosizioneValida(griglia, riga, colonna, numero))
                {
                    griglia[riga, colonna] = numero;
                    if (RiempieSchema(griglia, nextRiga, nextColonna))
                        return true;
                    griglia[riga, colonna] = 0;
                }
            }

            return false;
        }

        private bool PosizioneValida(int[,] griglia, int r, int c, int numero)
        {
            for (int i = 0; i < 9; i++)
                if (griglia[r, i] == numero || griglia[i, c] == numero)
                    return false;

            int startR = (r / 3) * 3;
            int startC = (c / 3) * 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (griglia[startR + i, startC + j] == numero)
                        return false;

            return true;
        }

        private int[,] RimuoviCelle(int[,] schema, Difficolta diff)
        {
            int[,] copia = (int[,])schema.Clone();
            Random rnd = new Random();
            int celleDaRimuovere = 30;
            if (diff == Difficolta.Facile)
            {
                celleDaRimuovere = 30;
            }
            else if (diff == Difficolta.Medio)
            {
                celleDaRimuovere = 40;
            }
            else if (diff == Difficolta.Difficile)
            {
                celleDaRimuovere = 50;
            }

            while (celleDaRimuovere > 0)
            {
                int r = rnd.Next(9);
                int c = rnd.Next(9);
                if (copia[r, c] != 0)
                {
                    copia[r, c] = 0;
                    celleDaRimuovere--;
                }
            }

            return copia;
        }

        private void Sudoku_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire da sudoku?",
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
                var nuovoForm = new Sudoku();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }

        private void BtnNuovaPartita_Click(object sender, EventArgs e)
        {
            if (CbDiff.SelectedItem.ToString() == "Facile")
            {
                NuovaPartita(Difficolta.Facile);
            }
            else if (CbDiff.SelectedItem.ToString() == "Medio")
            {
                NuovaPartita(Difficolta.Medio);
            }
            else if (CbDiff.SelectedItem.ToString() == "Difficile")
            {
                NuovaPartita(Difficolta.Difficile);
            }
        }

        private void BtnClassifica_Click(object sender, EventArgs e)
        {
            new Classifica("Sudoku").Show();
        }

        private bool CelleComplete()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (celle[r, c].Text == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int CalcolaPunteggio()
        {
            int puntiVittoria = 100;
            int puntiTempo = Math.Max(0, 250 - secondiTrascorsi);
            int puntiErrori = Math.Max(0, 70 - (errori * 10));
            int totale = puntiVittoria + puntiTempo + puntiErrori;
            return totale;
        }
        private void SalvaPunteggioNelJson(string utente, int punteggio)
        {
            string gioco = "Sudoku";
            int punteggioAttuale = GestionePunteggi.OttieniPunteggio(gioco, utente);
            if (!(punteggioAttuale > punteggio))
            {
                int nuovoPunteggio = punteggio;
                GestionePunteggi.AggiornaPunteggio(gioco, utente, nuovoPunteggio);
            }
        }

    }

    public enum Difficolta
    {
        Facile,
        Medio,
        Difficile
    }

}
