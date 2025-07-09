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
    public partial class Poker5 : Form
    {

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

            string tipo1 = ValutatorePoker.NomePunteggio(p1);
            string tipo2 = ValutatorePoker.NomePunteggio(p2);
            
            string risultato;
            if (p1 > p2)
            {
                risultato = $"Giocatore 1 vince con {tipo1}";
                vP1++;
                LblPP1.Text = $"{vP1}";
            }
            else if (p2 > p1)
            {
                risultato = $"Giocatore 2 vince con {tipo2}";
                vP2++;
                LblPP2.Text = $"{vP2}";
            }
            else
            {
                risultato = $"Pareggio con {tipo1}";
            }
            MessageBox.Show(risultato, "Risultato finale");
            if(vP1 >= 3 && vP1 > vP2)
            {
                MessageBox.Show("Il giocatore 1 ha vinto");
                vP1 = 0;
                LblPP1.Text = $"{vP1}";
                vP2 = 0;
                LblPP2.Text = $"{vP2}";
            }
            else if (vP2 >= 3 && vP2 > vP1)
            {
                MessageBox.Show("Il giocatore 2 ha vinto");
                vP1 = 0;
                LblPP1.Text = $"{vP1}";
                vP2 = 0;
                LblPP2.Text = $"{vP2}";
            }
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
                var nuovoForm = new Poker5(UtenteC.NomeU,UtenteC.NomeU2);
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
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
        public static int ValutaMano(List<Carta> mano)
        {
            var valori = mano.GroupBy(c => c.Valori).ToDictionary(g => g.Key, g => g.Count());
            var semi = mano.Select(c => c.Seme).Distinct().ToList();
            var pesi = mano.Select(c => c.Peso).OrderBy(p => p).ToList();

            bool isScala = pesi.Zip(pesi.Skip(1), (a, b) => b - a).All(diff => diff == 1);
            bool isColore = semi.Count == 1;

            if (isScala && isColore) return 8; // Scala colore
            if (valori.ContainsValue(4)) return 7; // Poker
            if (valori.ContainsValue(3) && valori.ContainsValue(2)) return 6; // Full
            if (isColore) return 5; // Colore
            if (isScala) return 4; // Scala
            if (valori.ContainsValue(3)) return 3; // Tris
            if (valori.Values.Count(v => v == 2) == 2) return 2; // Doppia coppia
            if (valori.ContainsValue(2)) return 1; // Coppia

            return 0; // Carta alta
        }

        public static string NomePunteggio(int valore)
        {
            switch (valore)
            {
                case 8:
                    return "Scala colore";
                case 7:
                    return "Poker";
                case 6:
                    return "Full";
                case 5:
                    return "Colore";
                case 4:
                    return "Scala";
                case 3:
                    return "Tris";
                case 2:
                    return "Doppia coppia";
                case 1:
                    return "Coppia";
                default:
                    return "Carta alta";
            };
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
