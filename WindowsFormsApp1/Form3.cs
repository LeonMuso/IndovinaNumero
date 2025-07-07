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
    public partial class Form3 : Form
    {
        string percorsoFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "punteggio2.txt");
        int secondiPassati = 0;



        public Form3()
        {
            InitializeComponent();

        }

        //punteggio = Victory + (global.TempoMassimo - secondiPassati) + global.Diff + (global.Tentativi* 2);
        //            string riga = $"{DateTime.Now:yyyy-MM-dd} - {nomeGiocatore} - Punteggio: {punteggio}" + Environment.NewLine;
        //            try
        //            {
        //                File.AppendAllText(percorsoFile, riga);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Salvataggio su file non possibile");
        //            }

        private void InizializzaCampo()
        {
            global2.griglia = new Button[global2.righe, global2.colonne];
            global2.celle = new Cella[global2.righe, global2.colonne];
            tabellaCampo.RowCount = global2.righe;
            tabellaCampo.ColumnCount = global2.colonne;
            tabellaCampo.Controls.Clear();
            tabellaCampo.RowStyles.Clear();
            tabellaCampo.ColumnStyles.Clear();

            for (int i = 0; i < global2.righe; i++)
                tabellaCampo.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / global2.righe));
            for (int j = 0; j < global2.colonne; j++)
                tabellaCampo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / global2.colonne));

            for (int r = 0; r < global2.righe; r++)
            {
                for (int c = 0; c < global2.colonne; c++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                    };
                    btn.MouseUp += CellaCliccata;

                    global2.griglia[r, c] = btn;
                    global2.celle[r, c] = new Cella
                    {
                        Riga = r,
                        Colonna = c
                    };

                    tabellaCampo.Controls.Add(btn, c, r);
                }
            }

            GeneraMine();
            CalcolaVicini();
        }

        private void GeneraMine()
        {
            var rand = new Random();
            int piazzate = 0;
            while (piazzate < global2.numeroMine)
            {
                int r = rand.Next(global2.righe);
                int c = rand.Next(global2.colonne);
                if (!global2.celle[r, c].IsMina)
                {
                    global2.celle[r, c].IsMina = true;
                    piazzate++;
                }
            }
        }
        private void tempoT_Tick(object sender, EventArgs e)
        {
            secondiPassati++;
            TimeSpan tempo = TimeSpan.FromSeconds(secondiPassati);
            LblTempoT.Text = $"Tempo trascorso: {tempo.Minutes:D2}:{tempo.Seconds:D2}";
        }

        private void CalcolaVicini()
        {
            for (int r = 0; r < global2.righe; r++)
            {
                for (int c = 0; c < global2.colonne; c++)
                {
                    if (global2.celle[r, c].IsMina) continue;

                    int count = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int nr = r + i;
                            int nc = c + j;
                            if (nr >= 0 && nr < global2.righe && nc >= 0 && nc < global2.colonne)
                                if (global2.celle[nr, nc].IsMina)
                                    count++;
                        }
                    global2.celle[r, c].MineVicino = count;
                }
            }
        }

        private void CellaCliccata(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            TableLayoutPanelCellPosition pos = tabellaCampo.GetPositionFromControl(btn);
            int r = pos.Row;
            int c = pos.Column;

            if (e.Button == MouseButtons.Right)
            {
                if (btn.Text == "🚩")
                {
                    btn.Text = "";
                    global2.nBandierine++;
                    LblBandierine.Text = $"Bandierine rimanenti:{global2.nBandierine}";
                }

                else
                {
                    btn.Text = "🚩";
                    global2.nBandierine--;
                    LblBandierine.Text = $"Bandierine rimanenti:{global2.nBandierine}";
                }

                return;
            }
            else if (e.Button == MouseButtons.Left)
            {
                var cella = global2.celle[r, c];
                var bottone = global2.griglia[r, c];

                // Se la cella è già rivelata e ha numero > 0 → prova apertura celle vicine
                if (cella.Rivelata && cella.MineVicino > 0)
                {
                    ApriCelleViciniSeBandiereCorrette(r, c);
                    return;
                }

                Rivelare(r, c);
            }
        }

        private void Rivelare(int r, int c)
        {
            var cella = global2.celle[r, c];
            var bottone = global2.griglia[r, c];

            if (cella.Rivelata || bottone.Text == "🚩") return;

            cella.Rivelata = true;
            bottone.Enabled = false;

            if (cella.IsMina)
            {
                bottone.Text = "💣";
                bottone.BackColor = Color.Red;
                FineGioco(false);
                return;
            }

            if (cella.MineVicino > 0)
            {
                bottone.Text = cella.MineVicino.ToString();
            }
            else
            {
                bottone.BackColor = Color.LightGray;
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                    {
                        int nr = r + i;
                        int nc = c + j;
                        if (nr >= 0 && nr < global2.righe && nc >= 0 && nc < global2.colonne)
                            Rivelare(nr, nc);
                    }
            }

            if (ControllaVittoria())
                FineGioco(true);
        }

        private void FineGioco(bool vittoria)
        {
            for (int r = 0; r < global2.righe; r++)
                for (int c = 0; c < global2.colonne; c++)
                    global2.griglia[r, c].Enabled = false;

            MessageBox.Show(vittoria ? "🎉 Hai vinto!" : "💥 Hai perso!");
            Close();
        }

        private bool ControllaVittoria()
        {
            for (int r = 0; r < global2.righe; r++)
                for (int c = 0; c < global2.colonne; c++)
                    if (!global2.celle[r, c].IsMina && !global2.celle[r, c].Rivelata)
                        return false;
            return true;
        }
        private void ApriCelleViciniSeBandiereCorrette(int r, int c)
        {
            int bandiereAttorno = 0;

            // Conta bandiere intorno
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    int nr = r + i;
                    int nc = c + j;

                    if (nr >= 0 && nr < global2.righe && nc >= 0 && nc < global2.colonne)
                    {
                        if (global2.griglia[nr, nc].Text == "🚩")
                        {
                            bandiereAttorno++;
                        }
                    }
                }

            if (bandiereAttorno == global2.celle[r, c].MineVicino)
            {
                // Se il numero di bandiere coincide con il numero nella cella
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int nr = r + i;
                        int nc = c + j;

                        if (nr >= 0 && nr < global2.righe && nc >= 0 && nc < global2.colonne)
                        {
                            var cella = global2.celle[nr, nc];
                            var bottone = global2.griglia[nr, nc];
                            if (bottone.Text != "🚩" && !cella.Rivelata)
                            {
                                Rivelare(nr, nc);
                            }
                        }
                    }
                }

            }
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            global2.righe = 5;
            global2.colonne = 5;
            global2.numeroMine = 3;
            global2.nBandierine = 5;
            InizializzaCampo();
            tempoT.Start();
        }

        private void BtnMedium_Click(object sender, EventArgs e)
        {
            global2.righe = 9;
            global2.colonne = 9;
            global2.numeroMine = 10;
            global2.nBandierine = 15;
            InizializzaCampo();
            tempoT.Start();
        }

        private void BtnHard_Click(object sender, EventArgs e)
        {
            global2.righe = 15;
            global2.colonne = 15;
            global2.numeroMine = 20;
            global2.nBandierine = 30;
            InizializzaCampo();
            tempoT.Start();
        }

        private void BtnImp_Click(object sender, EventArgs e)
        {
            global2.righe = 5;
            global2.colonne = 5;
            global2.numeroMine = 24;
            global2.nBandierine = 0;
            InizializzaCampo();
            tempoT.Start();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            
        }
    }
    public static class global2
    {
        public static Button[,] griglia;
        public static Cella[,] celle;
        public static int righe;
        public static int colonne;
        public static int numeroMine;
        public static int nBandierine;
    }
    public class Cella
    {
        public int Riga { get; set; }
        public int Colonna { get; set; }
        public bool IsMina { get; set; } = false;
        public bool Rivelata { get; set; } = false;
        public int MineVicino { get; set; } = 0;
    }

}

