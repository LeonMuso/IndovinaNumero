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
    public partial class Form3 : Form
    {

        // Modificabili 
        // Righe/Colonne per il campo (massimo 15*15)
        // nMine per il numero di mine (aggiungerne quando aumenti il campo)
        // nBandierine per il numero di bandiere (aggiungerne se si aumentano le mine)
        const int righe = 15;
        const int colonne = 15;
        const int numeroMine = 20;
        int nBandierine = 7;



        int secondiPassati = 0;

        private Button[,] griglia = new Button[righe, colonne];
        private Cella[,] celle = new Cella[righe, colonne];

        public Form3()
        {
            InitializeComponent();
            InizializzaCampo();
            tempoT.Start();
        }

        private void InizializzaCampo()
        {
            tabellaCampo.RowCount = righe;
            tabellaCampo.ColumnCount = colonne;
            tabellaCampo.Controls.Clear();
            tabellaCampo.RowStyles.Clear();
            tabellaCampo.ColumnStyles.Clear();

            for (int i = 0; i < righe; i++)
                tabellaCampo.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / righe));
            for (int j = 0; j < colonne; j++)
                tabellaCampo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / colonne));

            for (int r = 0; r < righe; r++)
            {
                for (int c = 0; c < colonne; c++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                    };
                    btn.MouseUp += CellaCliccata;

                    griglia[r, c] = btn;
                    celle[r, c] = new Cella { Riga = r, Colonna = c };

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
            while (piazzate < numeroMine)
            {
                int r = rand.Next(righe);
                int c = rand.Next(colonne);
                if (!celle[r, c].IsMina)
                {
                    celle[r, c].IsMina = true;
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
            for (int r = 0; r < righe; r++)
            {
                for (int c = 0; c < colonne; c++)
                {
                    if (celle[r, c].IsMina) continue;

                    int count = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int nr = r + i;
                            int nc = c + j;
                            if (nr >= 0 && nr < righe && nc >= 0 && nc < colonne)
                                if (celle[nr, nc].IsMina)
                                    count++;
                        }
                    celle[r, c].MineVicino = count;
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
                    nBandierine++;
                    LblBandierine.Text = $"Bandierine rimanenti:{nBandierine}";
                }

                else
                {
                    btn.Text = "🚩";
                    nBandierine--;
                    LblBandierine.Text = $"Bandierine rimanenti:{nBandierine}";
                }

                return;
            }
            else if (e.Button == MouseButtons.Left)
            {
                var cella = celle[r, c];
                var bottone = griglia[r, c];

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
            var cella = celle[r, c];
            var bottone = griglia[r, c];

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
                        if (nr >= 0 && nr < righe && nc >= 0 && nc < colonne)
                            Rivelare(nr, nc);
                    }
            }

            if (ControllaVittoria())
                FineGioco(true);
        }

        private void FineGioco(bool vittoria)
        {
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                    griglia[r, c].Enabled = false;

            MessageBox.Show(vittoria ? "🎉 Hai vinto!" : "💥 Hai perso!");
            Close();
        }

        private bool ControllaVittoria()
        {
            for (int r = 0; r < righe; r++)
                for (int c = 0; c < colonne; c++)
                    if (!celle[r, c].IsMina && !celle[r, c].Rivelata)
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

                    if (nr >= 0 && nr < righe && nc >= 0 && nc < colonne)
                    {
                        if (griglia[nr, nc].Text == "🚩")
                        {
                            bandiereAttorno++;
                        }
                    }
                }

            if (bandiereAttorno == celle[r, c].MineVicino)
            {
                // Se il numero di bandiere coincide con il numero nella cella
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int nr = r + i;
                        int nc = c + j;

                        if (nr >= 0 && nr < righe && nc >= 0 && nc < colonne)
                        {
                            var cella = celle[nr, nc];
                            var bottone = griglia[nr, nc];
                            if (bottone.Text != "🚩" && !cella.Rivelata)
                            {
                                Rivelare(nr, nc);
                            }
                        }
                    }
                }

            }
        }
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

