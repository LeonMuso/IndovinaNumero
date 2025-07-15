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
        private List<Giocatore> giocatori = new List<Giocatore>();
        private mazzo mazzo;
        private List<carta> carteComuni = new List<carta>();
        private int faseCarte = 0;
        private int piatto = 0;
        public PokerTexas()
        {
            InitializeComponent();

        }
        private void PokerTexas_Load(object sender, EventArgs e)
        {
            giocatori.Add(new Giocatore { Nome = "Giocatore 1", Soldi = 1000 });
            giocatori.Add(new Giocatore { Nome = "Giocatore 2", Soldi = 1000 });
            giocatori.Add(new Giocatore { Nome = "Giocatore 3", Soldi = 1000 });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            mazzo = new mazzo();
            carteComuni.Clear();
            faseCarte = 0;
            piatto = 0;

            foreach (var g in giocatori)
            {
                g.Mano = mazzo.Pesca(2);
                g.Foldato = false;
                g.PuntataAttuale = 0;
            }

            AggiornaGiocatori();
            pnlCarteComuni.Controls.Clear();
        }

        private void btnMostraVincitore_Click(object sender, EventArgs e)
        {
            MostraVincitore();
        }

        private void btnFaseSuccessiva_Click(object sender, EventArgs e)
        {
            MostraCarteComuni();
        }
        private void MostraCarteComuni()
        {
            int daPescare = faseCarte == 0 ? 3 : 1;
            carteComuni.AddRange(mazzo.Pesca(daPescare));
            faseCarte++;

            pnlCarteComuni.Controls.Clear();
            for (int i = 0; i < carteComuni.Count; i++)
            {
                Label lbl = new Label
                {
                    Text = carteComuni[i].ToString(),
                    Width = 60,
                    Height = 30,
                    Left = i * 65,
                    Top = 10,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlCarteComuni.Controls.Add(lbl);
            }

            btnMostraVincitore.Visible = faseCarte == 3;
        }

        private void MostraVincitore()
        {
            Giocatore vincitore = null;
            int punteggioMax = -1;

            foreach (var g in giocatori)
            {
                if (g.Foldato) continue;
                var tutte = g.Mano.Concat(carteComuni).ToList();
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
                MessageBox.Show($"Vince {vincitore.Nome} con punteggio {punteggioMax}! Ha vinto ${piatto}.", "Risultato");
            }
            else
            {
                MessageBox.Show("Tutti hanno foldato! Nessun vincitore.");
            }
        }

        private void AggiornaGiocatori()
        { // Giocatore 1
            lblNomiSoldi1.Text = giocatori[0].Nome + $"Soldi: ${giocatori[0].Soldi}";

            pnlGiocatore1.Controls.Clear();
            foreach (var carta in giocatori[0].Mano)
            {
                Label lbl = new Label { Text = carta.ToString(), Width = 60, Height = 30, BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter, Margin = new Padding(2) };
                pnlGiocatore1.Controls.Add(lbl);
            }

            // Giocatore 2
            lblNomiSoldi2.Text = giocatori[1].Nome + $"Soldi: ${giocatori[1].Soldi}";
            pnlGiocatore2.Controls.Clear();
            foreach (var carta in giocatori[1].Mano)
            {
                Label lbl = new Label
                {
                    Text = carta.ToString(),
                    Width = 60,
                    Height = 30,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(2)
                };
                pnlGiocatore2.Controls.Add(lbl);
            }

            // Giocatore 3
            lblNomiSoldi3.Text = giocatori[2].Nome + $"Soldi: ${giocatori[2].Soldi}";
            pnlGiocatore3.Controls.Clear();
            foreach (var carta in giocatori[2].Mano)
            {
                Label lbl = new Label
                {
                    Text = carta.ToString(),
                    Width = 60,
                    Height = 30,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(2)
                };
                pnlGiocatore3.Controls.Add(lbl);
            }

            // Aggiorna il piatto
            lblPiatto.Text = $"Piatto: ${piatto}";

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


    }
}

public class carta
{
    public string Seme { get; set; }
    public string Valore { get; set; }
    public override string ToString() => $"{Valore} di {Seme}";
}

public class mazzo
{
    private List<carta> carte;
    private Random rnd = new Random();

    public mazzo()
    {
        string[] semi = { "Cuori", "Quadri", "Fiori", "Picche" };
        string[] valori = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        carte = (from s in semi from v in valori select new carta { Seme = s, Valore = v }).ToList();
        carte = carte.OrderBy(c => rnd.Next()).ToList();
    }

    public List<carta> Pesca(int n)
    {
        var pescate = carte.Take(n).ToList();
        carte.RemoveRange(0, n);
        return pescate;
    }
}



public class Giocatore
{
    public string Nome { get; set; }
    public List<carta> Mano { get; set; } = new List<carta>();
    public int Soldi { get; set; }
    public bool Foldato { get; set; } = false;
    public int PuntataAttuale { get; set; } = 0;
    public bool AllIn => Soldi == 0;
}

public static class ValutatoreMano
{
    public static int ValutaMano(List<carta> carte)
    {
        // Mappa dei valori per ordinare
        Dictionary<string, int> valori = new Dictionary<string, int>
        {
            { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
            { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 },
            { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 }
        };

        // Ordina le carte per valore numerico decrescente
        var ordinate = carte.OrderByDescending(c => valori[c.Valore]).ToList();

        // Conta frequenze di valore e seme
        var gruppiValori = ordinate.GroupBy(c => c.Valore).OrderByDescending(g => g.Count()).ThenByDescending(g => valori[g.Key]);
        var gruppiSemi = ordinate.GroupBy(c => c.Seme);

        bool isFlush = gruppiSemi.Any(g => g.Count() >= 5);
        List<int> valoriUnici = ordinate.Select(c => valori[c.Valore]).Distinct().OrderByDescending(v => v).ToList();

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


