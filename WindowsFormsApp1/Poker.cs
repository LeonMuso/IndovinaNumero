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
    public partial class Poker5 : Form
    {
        int cambiP1 = 0;
        int cambiP2 = 0;
        private Mazzo mazzo;
        private List<Carta> manoGiocatore1;
        private List<Carta> manoGiocatore2;
        private FlowLayoutPanel flpMano1;
        private FlowLayoutPanel flpMano2;
        private List<int> selezione1 = new List<int>();
        private List<int> selezione2 = new List<int>();
        int vP1 = 0;
        int vP2 = 0;

        public Poker5(string p1, string p2)
        {
            InitializeComponent();
            LblUtente.Text = UtenteC.NomeU;
            LblP1.Text = p1;
            LblP12.Text = p1;
            LblP2.Text = p2;
            LblP22.Text = p2;
            LblPP1.Text = $"{vP1}";
            LblPP2.Text = $"{vP2}";
            flpMano1 = new FlowLayoutPanel
            {
                Name = "flpMano1",
                Location = new Point(20, 20),
                Size = new Size(400, 100),
                FlowDirection = FlowDirection.LeftToRight,
                AutoScroll = false
            };
            this.Controls.Add(flpMano1);

            flpMano2 = new FlowLayoutPanel
            {
                Name = "flpMano2",
                Location = new Point(20, 150),
                Size = new Size(400, 100),
                FlowDirection = FlowDirection.LeftToRight,
                AutoScroll = false
            };
            this.Controls.Add(flpMano2);
        }

        private void BtnDistribuisci_Click(object sender, EventArgs e)
        {
            mazzo = new Mazzo();
            mazzo.Mescola();
            BtnVincitore.Enabled = true;
            BtnCambioP1.Enabled = true;
            BtnCambioP2.Enabled = true;
            manoGiocatore1 = mazzo.Pesca(5);
            manoGiocatore2 = mazzo.Pesca(5);

            MostraManoGrafica(manoGiocatore1, flpMano1, selezione1);
            MostraManoGrafica(manoGiocatore2, flpMano2, selezione2);


        }

        private void MostraManoGrafica(List<Carta> mano, FlowLayoutPanel panel, List<int> indiciSelezionati)
        {
            panel.Controls.Clear();

            for (int i = 0; i < mano.Count; i++)
            {
                var carta = mano[i];

                Panel cartaPanel = new Panel
                {
                    Width = 60,
                    Height = 90,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = indiciSelezionati.Contains(i) ? Color.LightBlue : Color.White,
                    Margin = new Padding(5),
                    Tag = i
                };

                cartaPanel.Click += (s, e) =>
                {
                    int idx = (int)((Panel)s).Tag;

                    if (indiciSelezionati.Contains(idx))
                        indiciSelezionati.Remove(idx);
                    else
                        indiciSelezionati.Add(idx);


                    MostraManoGrafica(mano, panel, indiciSelezionati);
                };

                Label lbl = new Label
                {
                    Text = $"{carta.Valori}\n{carta.Seme}",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = (carta.Seme == "♥" || carta.Seme == "♦") ? Color.Red : Color.Black
                };

                lbl.Click += (s, e) =>
                {
                    int idx = (int)((Control)((Label)s).Parent).Tag;

                    if (indiciSelezionati.Contains(idx))
                        indiciSelezionati.Remove(idx);
                    else
                        indiciSelezionati.Add(idx);


                    MostraManoGrafica(mano, panel, indiciSelezionati);
                };

                cartaPanel.Controls.Add(lbl);
                panel.Controls.Add(cartaPanel);
            }
        }

        private void ValutaVincitore()
        {
            int p1 = ValutatorePoker.ValutaMano(manoGiocatore1);
            int p2 = ValutatorePoker.ValutaMano(manoGiocatore2);

            string vincitore = "";
            int puntiVittoria = 150;

            string risultato;
            if (p1 > p2)
            {
                risultato = $"{UtenteC.NomeU} vince con {p1}";
                vP1++;
                LblPP1.Text = $"{vP1}";
                BtnCambioP1.Enabled = true;
                BtnCambioP2.Enabled = true;
            }
            else if (p2 > p1)
            {
                risultato = $"{UtenteC.NomeU2} vince con {p2}";
                vP2++;
                LblPP2.Text = $"{vP2}";
                BtnCambioP1.Enabled = true;
                BtnCambioP2.Enabled = true;
            }
            else
            {
                risultato = $"Pareggio con {p1}";
                BtnCambioP1.Enabled = true;
                BtnCambioP2.Enabled = true;
            }
            MessageBox.Show(risultato, "Risultato finale");
            if (vP1 >= 3 && vP1 > vP2)
            {
                MessageBox.Show("Il giocatore 1 ha vinto");
                vincitore = UtenteC.NomeU;
                int punteggio = puntiVittoria - (10 * cambiP1);
                MessageBox.Show("         --Punteggio--" +
                                "\n" + $"Vittoria +{puntiVittoria}" +
                                "\n" + $"Cambi -{cambiP1 * 10}" +
                                "\n" + $"Punteggio finale: {punteggio}", $"Vittoria {UtenteC.NomeU}");
                SalvaPunteggio("Poker", vincitore, punteggio);
                vP1 = 0;
                LblPP1.Text = $"{vP1}";
                vP2 = 0;
                LblPP2.Text = $"{vP2}";
            }
            else if (vP2 >= 3 && vP2 > vP1)
            {
                MessageBox.Show("Il giocatore 2 ha vinto");
                vincitore = UtenteC.NomeU2;
                int punteggio = puntiVittoria - (10 * cambiP2);
                MessageBox.Show("         --Punteggio--" +
                                "\n" + $"Vittoria +{puntiVittoria}" +
                                "\n" + $"Cambi -{cambiP2 * 10}" +
                                "\n" + $"Punteggio finale: {punteggio}", $"Vittoria {UtenteC.NomeU2}");
                SalvaPunteggio("Poker", vincitore, punteggio);
                vP1 = 0;
                LblPP1.Text = $"{vP1}";
                vP2 = 0;
                LblPP2.Text = $"{vP2}";
            }
        }
        void SalvaPunteggio(string gioco, string utente, int punti)
        {
            string path = "Punteggi.json";
            var dict = new Dictionary<string, Dictionary<string, int>>();

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(json)
                       ?? new Dictionary<string, Dictionary<string, int>>();
            }

            if (!dict.ContainsKey(gioco))
                dict[gioco] = new Dictionary<string, int>();

            if (dict[gioco].ContainsKey(utente))
                dict[gioco][utente] += punti;
            else
                dict[gioco][utente] = punti;

            File.WriteAllText(path, JsonConvert.SerializeObject(dict, Formatting.Indented));
        }


        private void BtnCambioP1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selezione1.Count; i++)
            {
                int idx = selezione1[i];
                manoGiocatore1[idx] = mazzo.Pesca(1)[0];
            }
            selezione1.Clear();
            MostraManoGrafica(manoGiocatore1, flpMano1, selezione1);
            BtnCambioP1.Enabled = false;
            cambiP1++;
        }

        private void BtnCambioP2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selezione2.Count; i++)
            {
                int idx = selezione2[i];
                manoGiocatore2[idx] = mazzo.Pesca(1)[0];
            }
            selezione2.Clear();
            MostraManoGrafica(manoGiocatore2, flpMano2, selezione2);
            BtnCambioP2.Enabled = false;
            cambiP2++;
        }

        private void BtnVincitore_Click(object sender, EventArgs e)
        {
            ValutaVincitore();
            mazzo = new Mazzo();
            mazzo.Mescola();
            manoGiocatore1 = mazzo.Pesca(5);
            manoGiocatore2 = mazzo.Pesca(5);
            MostraManoGrafica(manoGiocatore1, flpMano1, selezione1);
            MostraManoGrafica(manoGiocatore2, flpMano2, selezione2);
        }

        private void Poker5_FormClosing(object sender, FormClosingEventArgs e)
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
                var nuovoForm = new Poker5(UtenteC.NomeU, UtenteC.NomeU2);
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }

        private void BtnClassifica_Click(object sender, EventArgs e)
        {
            new Classifica("Poker").Show();
        }
    }

    public class Carta
    {
        public string Seme { get; set; }
        public string Valori { get; set; }
        public int Peso { get; set; }
        public override string ToString()
        {
            return $"{Valori}{Seme}";
        }
    }
    public static class ValutatorePoker
    {
        public static int ValutaMano(List<Carta> carte)
        {
            // Mappa dei valori per ordinare
            Dictionary<string, int> valori = new Dictionary<string, int>
        {
            { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
            { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 },
            { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 }
        };

            // Ordina le carte per valore numerico decrescente
            var ordinate = carte.OrderByDescending(c => valori[c.Valori]).ToList();

            // Conta frequenze di valore e seme
            var gruppiValori = ordinate.GroupBy(c => c.Valori).OrderByDescending(g => g.Count()).ThenByDescending(g => valori[g.Key]);
            var gruppiSemi = ordinate.GroupBy(c => c.Seme);

            bool isFlush = gruppiSemi.Any(g => g.Count() >= 5);
            List<int> valoriUnici = ordinate.Select(c => valori[c.Valori]).Distinct().OrderByDescending(v => v).ToList();

            // Controllo scala
            bool isStraight = false;
            for (int i = 0; i < valoriUnici.Count - 4; i++)
            {
                if (valoriUnici[i] - 1 == valoriUnici[i + 1] &&
                    valoriUnici[i + 1] - 1 == valoriUnici[i + 2] &&
                    valoriUnici[i + 2] - 1 == valoriUnici[i + 3] &&
                    valoriUnici[i + 3] - 1 == valoriUnici[i + 4])
                {
                    isStraight = true;
                    break;
                }
            }

            // Scala bassa (A-2-3-4-5)
            if (!isStraight && valoriUnici.Contains(14) && valoriUnici.Contains(2) && valoriUnici.Contains(3) && valoriUnici.Contains(4) && valoriUnici.Contains(5))
            {
                isStraight = true;
            }

            // Scala colore (straight flush)
            if (isFlush && isStraight)
                return 9000;

            // Poker
            if (gruppiValori.First().Count() == 4)
                return 8000 + valori[gruppiValori.First().Key];

            // Full
            if (gruppiValori.First().Count() == 3 && gruppiValori.Skip(1).Any(g => g.Count() >= 2))
                return 7000 + valori[gruppiValori.First().Key];

            // Colore
            if (isFlush)
                return 6000 + valoriUnici.Max();

            // Scala
            if (isStraight)
                return 5000 + valoriUnici.Max();

            // Tris
            if (gruppiValori.First().Count() == 3)
                return 4000 + valori[gruppiValori.First().Key];

            // Doppia coppia
            if (gruppiValori.First().Count() == 2 && gruppiValori.Skip(1).Any(g => g.Count() == 2))
            {
                int val1 = valori[gruppiValori.First().Key];
                int val2 = valori[gruppiValori.Skip(1).First(g => g.Count() == 2).Key];
                return 3000 + val1 * 14 + val2;
            }

            // Coppia
            if (gruppiValori.First().Count() == 2)
                return 2000 + valori[gruppiValori.First().Key];

            // Carta alta
            return 1000 + valoriUnici.Max();
        }
    }
    public class Mazzo
    {
        private List<Carta> carte;
        private static readonly string[] semi = { "♠", "♣", "♥", "♦" };
        private static readonly string[] valori = { "9", "10", "J", "Q", "K", "A" };
        public Mazzo()
        {
            carte = new List<Carta>();
            int peso = 9;
            foreach (string v in valori)
            {
                foreach (string s in semi)
                {
                    carte.Add(new Carta { Seme = s, Valori = v, Peso = peso });
                }
                peso++;
            }
        }
        public void Mescola()
        {
            var rnd = new Random();
            carte = carte.OrderBy(c => rnd.Next()).ToList();
        }
        public List<Carta> Pesca(int quante)
        {
            var prese = carte.Take(quante).ToList();
            carte.RemoveRange(0, quante);
            return prese;
        }
    }

}
