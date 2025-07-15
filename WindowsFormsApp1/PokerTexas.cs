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
        private mazzo mazzo;
        private List<Giocatore> giocatori;
        private List<carta> carteComuni;
        private Label lblInfo; private Panel[] pannelliGiocatori;
        private Panel pannelloComuni; private Button btnLogin1;
        private Button btnLogin2; private Button btnStart;
        private Button btnFaseSuccessiva;
        private string nome1 = "Giocatore 1";
        private string nome2 = "Giocatore 2";
        private string nome3 = "Giocatore 3";
        private int piatto = 0;
        public static ListBox listBoxLog = new ListBox { Width = 400, Height = 150, Left = 10, Top = 300 };
        public int faseCarte = 0; // 0 = nessuna, 1 = flop, 2 = turn, 3 = river
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
            btnFaseSuccessiva = new Button { Text = "Fase successiva", Top = 390, Left = 550 };

            pannelliGiocatori = new Panel[3];
            for (int i = 0; i < 3; i++)
            {
                pannelliGiocatori[i] = new Panel { Width = 300, Height = 180, Top = 50 + i * 190, Left = 10, BorderStyle = BorderStyle.FixedSingle };
                Controls.Add(pannelliGiocatori[i]);
            }

            pannelloComuni = new Panel { Width = 600, Height = 150, Top = 50, Left = 320, BorderStyle = BorderStyle.FixedSingle };
            Controls.Add(pannelloComuni);

            btnLogin1 = new Button { Text = "Login Giocatore 2", Top = 420, Left = 550 };
            btnLogin1.Click += (s, e) =>
            {
                nome2 = Prompt("Inserisci nome Giocatore 2:", nome1);
                btnLogin1.Visible = false;
            };
            Controls.Add(btnLogin1);

            btnLogin2 = new Button { Text = "Login Giocatore 3", Top = 450, Left = 550 };
            btnLogin2.Click += (s, e) =>
            {
                nome3 = Prompt("Inserisci nome Giocatore 3:", nome2);
                btnLogin2.Visible = false;
            };
            Controls.Add(btnLogin2);

            btnStart = new Button { Text = "Inizia Partita", Top = 480, Left = 550 };
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
            mazzo = new mazzo();
            mazzo.Mischia();
            piatto = 0;

            giocatori = new List<Giocatore>()
    {
        new Giocatore { Nome = UtenteC.NomeU },
        new Giocatore { Nome = nome2 },
        new Giocatore { Nome = nome3 }
    };

            carteComuni = new List<carta>();

            foreach (var g in giocatori)
            {
                g.Mano.Clear();
                g.Foldato = false;
                g.PuntataAttuale = 0;
                if (g.Soldi <= 0) g.Foldato = true;
                g.Mano.Add(mazzo.Pesca(1)[0]);
                g.Mano.Add(mazzo.Pesca(1)[0]);
            }

            carteComuni.Add(mazzo.Pesca(1)[0]);
            carteComuni.Add(mazzo.Pesca(1)[0]);
            carteComuni.Add(mazzo.Pesca(1)[0]);
            carteComuni.Add(mazzo.Pesca(1)[0]);
            carteComuni.Add(mazzo.Pesca(1)[0]);

            for (int i = 0; i < 3; i++)
                MostraGiocatore(giocatori[i], pannelliGiocatori[i], i, () => MostraCarteComuni(pannelloComuni, btnStart, giocatori, mazzo, piatto));

            MostraCarteComuni(pannelloComuni, btnStart, giocatori, mazzo, piatto);
        }

        public void MostraGiocatore(Giocatore g, Panel pannello, int index, Action aggiornaCarteComuni)
        {
            pannello.Controls.Clear();
            Label lbl = new Label { Text = g.Nome + $" ({g.Soldi}$)", Left = 5, Top = 5, AutoSize = true };
            pannello.Controls.Add(lbl);

            int x = 5;
            foreach (var carta in g.Mano)
            {
                var lblCarta = new Label
                {
                    Text = carta.ToString(),
                    Width = 100,
                    Height = 30,
                    Left = x,
                    Top = 30,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = (carta.Seme == "Cuori" || carta.Seme == "Quadri") ? Color.Red : Color.Black
                };
                pannello.Controls.Add(lblCarta);
                x += 110;
            }

            Button btnPunta = new Button { Text = "Punta 100", Left = 5, Top = 70, Width = 100 };
            Button btnFold = new Button { Text = "Fold", Left = 115, Top = 70, Width = 100 };

            btnPunta.Click += (s, e) =>
            {
                if (g.Soldi >= 100)
                {
                    g.Soldi -= 100;
                    g.PuntataAttuale += 100;
                    listBoxLog.Items.Add($"{g.Nome} punta 100$");
                }
                else
                {
                    g.PuntataAttuale += g.Soldi;
                    listBoxLog.Items.Add($"{g.Nome} fa All-In con {g.Soldi}$!");
                    g.Soldi = 0;
                }
                MostraGiocatore(g, pannello, index, aggiornaCarteComuni);
            };

            btnFold.Click += (s, e) =>
            {
                g.Foldato = true;
                listBoxLog.Items.Add($"{g.Nome} ha foldato");
                MostraGiocatore(g, pannello, index, aggiornaCarteComuni);
            };

            btnPunta.Enabled = !g.Foldato && g.Soldi > 0;
            btnFold.Enabled = !g.Foldato;

            pannello.Controls.Add(btnPunta);
            pannello.Controls.Add(btnFold);

        }

        public void MostraCarteComuni(Panel pannelloComuni, Button btnStart, List<Giocatore> giocatori, mazzo mazzo, int piatto)
        {
            pannelloComuni.Controls.Clear();
            Label titolo = new Label { Text = "Carte Comuni:", Left = 5, Top = 5, AutoSize = true };
            pannelloComuni.Controls.Add(titolo);

            int daPescare = 0;
            if (faseCarte == 0) daPescare = 3; // Flop
            else if (faseCarte == 1) daPescare = 1; // Turn
            else if (faseCarte == 2) daPescare = 1; // River

            carteComuni.AddRange(mazzo.Pesca(daPescare));
            faseCarte++;

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

            if (faseCarte > 2)
            {
                Button btnMostraVincitore = new Button { Text = "Mostra Vincitore", Top = 100, Left = 400 };
                btnMostraVincitore.Click += (s, e) =>
                {
                    Giocatore vincitore = null;
                    int punteggioMax = -1;

                    foreach (var g in giocatori)
                    {
                        if (g.Foldato) continue;
                        var tutte = g.Mano.Concat(carteComuni).ToList();
                        int punteggio = ValutatoreMano.ValutaMano(tutte);
                        listBoxLog.Items.Add($"{g.Nome} ha un punteggio di {punteggio}");
                        if (punteggio > punteggioMax)
                        {
                            vincitore = g;
                            punteggioMax = punteggio;
                        }
                    }

                    if (vincitore != null)
                    {
                        vincitore.Soldi += piatto;
                        listBoxLog.Items.Add($"{vincitore.Nome} vince ${piatto} con punteggio {punteggioMax}!");
                        MessageBox.Show($"Vince {vincitore.Nome} con punteggio {punteggioMax}! Ha vinto ${piatto}.", "Risultato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        listBoxLog.Items.Add("Tutti hanno foldato! Nessun vincitore.");
                        MessageBox.Show("Tutti hanno foldato! Nessun vincitore.");
                    }

                    faseCarte = 0;
                    carteComuni.Clear();
                    btnStart.PerformClick();
                };

                pannelloComuni.Controls.Add(btnMostraVincitore);
            }

            btnFaseSuccessiva.Click += (s, e) =>
            {
                MostraCarteComuni(pannelloComuni, btnStart, giocatori, mazzo, piatto);
            };
            pannelloComuni.Controls.Add(btnFaseSuccessiva);

            pannelloComuni.Controls.Add(listBoxLog);

        }


        private void PokerTexas_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire da poker?",
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
                var nuovoForm = new PokerTexas();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }
        public void NuovaMano(List<Giocatore> giocatori, mazzo mazzo, out List<carta> carteComuni)
        {
            carteComuni = new List<carta>(); mazzo.Mischia();

            foreach (var g in giocatori)
            {
                g.Mano = mazzo.Pesca(2);
                g.Foldato = false;
                g.PuntataAttuale = 0;
            }

        }
        public void AssegnaVincita(Giocatore vincitore, int piatto)
        {
            vincitore.Soldi += piatto;
            MessageBox.Show($"{vincitore.Nome} ha vinto la mano e guadagna {piatto}$! Ora ha {vincitore.Soldi}$.");
        }

        public bool Scommetti(Giocatore g, int importo)
        {
            if (g.Soldi >= importo)
            {
                g.Soldi -= importo;
                g.PuntataAttuale += importo;
                return true;
            }
            else if (g.Soldi > 0)
            {
                g.PuntataAttuale += g.Soldi;
                g.Soldi = 0;
                MessageBox.Show($"{g.Nome} non ha abbastanza soldi: fa All-In con tutto ciò che ha!");
                return true;
            }
            return false;
        }
        public int GiroDiPuntate(List<Giocatore> giocatori)
        {
            int piatto = 0; int puntataMassima = 0;

            foreach (var g in giocatori.Where(x => !x.Foldato))
            {
                int puntata = ChiediPuntata(g, puntataMassima);

                if (puntata == -1)
                {
                    g.Foldato = true;
                }
                else
                {
                    Scommetti(g, puntata);
                    if (g.PuntataAttuale > puntataMassima)
                        puntataMassima = g.PuntataAttuale;
                }
            }
            foreach (var g in giocatori.Where(x => !x.Foldato && x.PuntataAttuale < puntataMassima))
            {
                int differenza = puntataMassima - g.PuntataAttuale;

                if (g.Soldi <= differenza)
                {
                    Scommetti(g, g.Soldi);
                }
                else
                {
                    DialogResult res = MessageBox.Show($"{g.Nome}, vuoi chiamare con {differenza}$ o foldare?", "Chiamata", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Scommetti(g, differenza);
                    }
                    else
                    {
                        g.Foldato = true;
                    }
                }
            }

            piatto = giocatori.Sum(g => g.PuntataAttuale);
            return piatto;

        }
        private int ChiediPuntata(Giocatore g, int attuale)
        {
            if (g.Soldi == 0) return 0;

            string input = Microsoft.VisualBasic.Interaction.InputBox($"{g.Nome}, la puntata attuale è {attuale}$. Inserisci la tua puntata (-1 per fold):", "Puntata", attuale.ToString());
            if (int.TryParse(input, out int valore))
                return valore;
            return -1;

        }
        public Giocatore ValutaMani(List<Giocatore> attivi, List<carta> comuni)
        {
            Giocatore vincente = attivi[0]; int migliorValore = 0;

            foreach (var g in attivi)
            {
                var mano = new List<carta>();
                mano.AddRange(g.Mano);
                mano.AddRange(comuni);

                int valore = CalcolaValoreManoCompleto(mano);
                if (valore > migliorValore)
                {
                    migliorValore = valore;
                    vincente = g;
                }
            }
            return vincente;

        }
        private int CalcolaValoreManoCompleto(List<carta> carte)
        {
            var semi = carte.GroupBy(c => c.Seme); var valori = carte.Select(c => c.Valore).Distinct().OrderBy(x => x).ToList(); bool isScala = valori.Count >= 5 && valori.Zip(valori.Skip(1), (a, b) => b - a).All(x => x == 1); bool isColore = semi.Any(g => g.Count() >= 5);

            var gruppi = carte.GroupBy(c => c.Valore).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key);

            if (isScala && isColore) return 9000 + valori.Max(); // scala colore
            if (gruppi.First().Count() == 4) return 8000 + gruppi.First().Key; // poker
            if (gruppi.First().Count() == 3 && gruppi.Skip(1).Any(g => g.Count() >= 2)) return 7000 + gruppi.First().Key; // full
            if (isColore) return 6000 + valori.Max(); // colore
            if (isScala) return 5000 + valori.Max(); // scala
            if (gruppi.First().Count() == 3) return 4000 + gruppi.First().Key; // tris
            if (gruppi.Count(g => g.Count() == 2) >= 2) return 3000 + gruppi.First().Key; // doppia coppia
            if (gruppi.First().Count() == 2) return 2000 + gruppi.First().Key; // coppia

            return 1000 + valori.Max(); // carta alta

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
            else if (Valore == 12)
            {
                nome = "Q";
            }
            else if (Valore == 13)
            {
                nome = "K";
            }
            else if (Valore == 14)
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
        public int Soldi { get; set; } = 1000;
        public List<carta> Mano { get; set; } = new List<carta>();
        public bool Foldato { get; set; } = false;
        public int PuntataAttuale { get; set; } = 0;
        public bool AllIn => Soldi == 0;
    }

    public static class ValutatoreMano
    {
        public static int ValutaMano(List<carta> carte)
        {
            var semi = carte.GroupBy(c => c.Seme);
            var valori = carte.Select(c => c.Valore).Distinct().OrderBy(x => x).ToList();
            bool isScala = valori.Count >= 5 && valori.Zip(valori.Skip(1), (a, b) => b - a).All(x => x == 1);
            bool isColore = semi.Any(g => g.Count() >= 5);

            var gruppi = carte.GroupBy(c => c.Valore).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key);

            if (isScala && isColore) return 9000 + valori.Max();
            if (gruppi.First().Count() == 4) return 8000 + gruppi.First().Key;
            if (gruppi.First().Count() == 3 && gruppi.Skip(1).Any(g => g.Count() >= 2)) return 7000 + gruppi.First().Key;
            if (isColore) return 6000 + valori.Max();
            if (isScala) return 5000 + valori.Max();
            if (gruppi.First().Count() == 3) return 4000 + gruppi.First().Key;
            if (gruppi.Count(g => g.Count() == 2) >= 2) return 3000 + gruppi.First().Key;
            if (gruppi.First().Count() == 2) return 2000 + gruppi.First().Key;

            return 1000 + valori.Max();
        }
    }
}
