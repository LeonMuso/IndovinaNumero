using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class PokerTexas : Form
    {
        private Mazzo mazzo;
        private List<Giocatore> giocatori;
        private List<Carta> carteComuni;
        private Label lblInfo; private Panel[] pannelliGiocatori;
        private Panel pannelloComuni; private Button btnLogin1;
        private Button btnLogin2; private Button btnStart;
        private string nome1 = "Giocatore 1";
        private string nome2 = "Giocatore 2";
        private string nome3 = "Giocatore 3";
        private int piatto = 0;
        public PokerTexas()
        {
            InitializeComponent();
            InizializzaComponentiPersonalizzati();
        }

        private void InizializzaComponentiPersonalizzati()
        {
            this.Size = new Size(900, 700);
            lblInfo = new Label { Text = "Texas Hold'em - 3 Giocatori", AutoSize = true, Top = 10, Left = 10 };
            Controls.Add(lblInfo);

            pannelliGiocatori = new Panel[3];
            for (int i = 0; i < 3; i++)
            {
                pannelliGiocatori[i] = new Panel { Width = 300, Height = 180, Top = 50 + i * 190, Left = 10, BorderStyle = BorderStyle.FixedSingle };
                Controls.Add(pannelliGiocatori[i]);
            }

            pannelloComuni = new Panel { Width = 600, Height = 150, Top = 50, Left = 320, BorderStyle = BorderStyle.FixedSingle };
            Controls.Add(pannelloComuni);

            btnLogin1 = new Button { Text = "Login Giocatore 1", Top = 620, Left = 650 };
            btnLogin1.Click += (s, e) => { nome1 = Prompt("Inserisci nome Giocatore 1:", nome1); };
            Controls.Add(btnLogin1);

            btnLogin2 = new Button { Text = "Login Giocatore 2", Top = 650, Left = 650 };
            btnLogin2.Click += (s, e) => { nome2 = Prompt("Inserisci nome Giocatore 2:", nome2); };
            Controls.Add(btnLogin2);

            btnStart = new Button { Text = "Inizia Partita", Top = 680, Left = 650 };
            btnStart.Click += (s, e) => IniziaPartita();
            Controls.Add(btnStart);
        }

        private string Prompt(string text, string defaultValue)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 250;
                prompt.Height = 150;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.Text = text;

                Label textLabel = new Label() { Left = 10, Top = 10, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 200, Text = defaultValue };
                Button confirmation = new Button() { Text = "OK", Left = 70, Width = 100, Top = 60, DialogResult = DialogResult.OK };

                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : defaultValue;
            }
        }

        private void IniziaPartita()
        {
            mazzo = new Mazzo();
            mazzo.Mescola();
            piatto = 0;

            giocatori = new List<Giocatore>()
    {
        new Giocatore { Nome = nome1 },
        new Giocatore { Nome = nome2 },
        new Giocatore { Nome = nome3 }
    };

            carteComuni = new List<Carta>();

            foreach (var g in giocatori)
            {
                g.Mano.Clear();
                g.Foldato = false;
                g.PuntataCorrente = 0;
                if (g.Soldi <= 0) g.Foldato = true;
                g.Mano.Add(mazzo.Pesca());
                g.Mano.Add(mazzo.Pesca());
            }

            carteComuni.Add(mazzo.Pesca());
            carteComuni.Add(mazzo.Pesca());
            carteComuni.Add(mazzo.Pesca());
            carteComuni.Add(mazzo.Pesca());
            carteComuni.Add(mazzo.Pesca());

            for (int i = 0; i < 3; i++)
                MostraMano(pannelliGiocatori[i], giocatori[i], i);

            MostraCarteComuni();
        }

        private void MostraMano(Panel pannello, Giocatore g, int index)
        {
            pannello.Controls.Clear();
            Label nome = new Label { Text = g.Nome + $" (${g.Soldi})", Top = 5, Left = 5, AutoSize = true };
            pannello.Controls.Add(nome);

            for (int i = 0; i < g.Mano.Count; i++)
            {
                var lbl = new Label
                {
                    Text = g.Mano[i].ToString(),
                    Width = 100,
                    Height = 30,
                    Left = 10 + i * 110,
                    Top = 30,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pannello.Controls.Add(lbl);
            }

            Button btnPunta = new Button { Text = "Punta 100", Width = 80, Left = 10, Top = 70 };
            Button btnFold = new Button { Text = "Fold", Width = 80, Left = 100, Top = 70 };

            btnPunta.Click += (s, e) =>
            {
                if (g.Soldi >= 100)
                {
                    g.Soldi -= 100;
                    g.PuntataCorrente += 100;
                    piatto += 100;
                    MostraMano(pannello, g, index);
                }
                else
                {
                    MessageBox.Show("Non hai abbastanza soldi.");
                    g.Foldato = true;
                    MostraMano(pannello, g, index);
                }
            };

            btnFold.Click += (s, e) =>
            {
                g.Foldato = true;
                MostraMano(pannello, g, index);
            };

            btnPunta.Enabled = !g.Foldato && g.Soldi >= 100;
            btnFold.Enabled = !g.Foldato;

            pannello.Controls.Add(btnPunta);
            pannello.Controls.Add(btnFold);
        }

        private void MostraCarteComuni()
        {
            pannelloComuni.Controls.Clear();
            Label titolo = new Label { Text = "Carte Comuni:", Left = 5, Top = 5, AutoSize = true };
            pannelloComuni.Controls.Add(titolo);

            for (int i = 0; i < carteComuni.Count; i++)
            {
                var lbl = new Label
                {
                    Text = carteComuni[i].ToString(),
                    Width = 100,
                    Height = 30,
                    Left = 10 + i * 110,
                    Top = 40,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pannelloComuni.Controls.Add(lbl);
            }

            Button btnMostraVincitore = new Button { Text = "Mostra Vincitore", Top = 100, Left = 400 };
            btnMostraVincitore.Click += (s, e) => MostraVincitore();
            pannelloComuni.Controls.Add(btnMostraVincitore);
        }

        private void MostraVincitore()
        {
            Giocatore vincitore = null;
            int punteggioMax = -1;

            foreach (var g in giocatori)
            {
                if (g.Foldato) continue;
                var tutte = g.Mano.Concat(carteComuni).ToList();   //g.Mano.Concat(carteComuni).ToList();
                int punteggio = ValutatoreMano.ValutaMano(tutte);
                if (punteggio > punteggioMax)
                {
                    vincitore = g;
                    punteggioMax = punteggio;
                }
            }

            if (vincitore != null)
            {
                vincitore.Soldi += piatto;
                MessageBox.Show($"Vince {vincitore.Nome} con punteggio {punteggioMax}! Ha vinto ${piatto}.", "Risultato", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tutti hanno foldato! Nessun vincitore.");
            }

            btnStart.PerformClick(); // nuova mano automatica
        }

    }

    public class carta
    {
        public string Seme { get; set; } // ♠ ♥ ♦ ♣
        public int Valore { get; set; } // Da 2 a 14 (11 = Jack, 12 = Queen, ecc.)

        public override string ToString()
        {
            string nome;
            if (Valore == 11)
            {
                nome = "J";
            }
            else if(Valore == 12)
            {
                nome = "Q";
            }
            else if (Valore == 13)
            {
                nome = "K";
            }
            else if( Valore == 14)
            {
                nome = "A";
            }
            else
            {
                nome = Valore.ToString();
            }

            
            return $"{nome} di {Seme}";
        }
    }

    public class mazzo
    {
        private List<carta> carte;
        private static readonly string[] semi = { "♠", "♥", "♦", "♣" };

        public mazzo()
        {
            carte = new List<carta>();
            for (int valore = 2; valore <= 14; valore++)
            {
                foreach (var seme in semi)
                {
                    carte.Add(new carta { Valore = valore, Seme = seme });
                }
            }

            Mischia();
        }

        public void Mischia()
        {
            var rand = new Random();
            carte = carte.OrderBy(c => rand.Next()).ToList();
        }

        public List<carta> Pesca(int quante)
        {
            var prese = carte.Take(quante).ToList();
            carte.RemoveRange(0, quante);
            return prese;
        }
    }


    public class Giocatore
    {
        public string Nome { get; set; }
        public List<carta> Mano { get; set; } = new List<carta>();
        public bool Foldato { get; set; } = false;
        public int Punteggio { get; set; } = 0;
        public int Soldi { get; set; } = 1000;
        public int PuntataCorrente { get; set; } = 0;
    }

    public static class ValutatoreMano
    {
        private static readonly Dictionary<string, int> valori = new Dictionary<string, int>()
        { ["2"] = 2, ["3"] = 3, ["4"] = 4, ["5"] = 5, ["6"] = 6, ["7"] = 7, ["8"] = 8, ["9"] = 9, ["10"] = 10, ["J"] = 11, ["Q"] = 12, ["K"] = 13, ["A"] = 14 };

        public static int ValutaMano(List<carta> manoCompleta)
        {
            var gruppi = manoCompleta.GroupBy(c => c.Valore).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key);
            var ordinati = manoCompleta.Select(c => c.Valore).OrderBy(v => v).ToList();
            var semi = manoCompleta.GroupBy(c => c.Seme);

            bool isScala = ordinati.Zip(ordinati.Skip(1), (a, b) => b - a).All(x => x == 1);
            bool isColore = semi.Any(g => g.Count() >= 5);

            if (isScala && isColore) return 800;
            if (gruppi.First().Count() == 4) return 700;
            if (gruppi.First().Count() == 3 && gruppi.Skip(1).First().Count() == 2) return 600;
            if (isColore) return 500;
            if (isScala) return 400;
            if (gruppi.First().Count() == 3) return 300;
            if (gruppi.First().Count() == 2 && gruppi.Skip(1).First().Count() == 2) return 200;
            if (gruppi.First().Count() == 2) return 100;

            return 0;
        }

    }
}
