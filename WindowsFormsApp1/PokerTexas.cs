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
        private int fase = 0;
        private int piatto = 0;
        public PokerTexas(string p1, string p2, string p3)
        {
            InitializeComponent();

        }
        private void PokerTexas_Load(object sender, EventArgs e)
        {
            giocatori.Add(new Giocatore { Nome = UtenteC.NomeU, Soldi = 1000 });
            giocatori.Add(new Giocatore { Nome = UtenteC.NomeU2, Soldi = 1000 });
            giocatori.Add(new Giocatore { Nome = UtenteC.NomeU3, Soldi = 1000 });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnFaseSuccessiva.Enabled = true;
            btnPunta1.Enabled = true; btnPunta2.Enabled = true; btnPunta3.Enabled = true;
            btnFold1.Enabled = true; btnFold2.Enabled = true; btnFold3.Enabled = true;
            mazzo = new mazzo();
            carteComuni.Clear();
            fase = 0;
            piatto = 0;

            foreach (var g in giocatori)
            {
                g.Mano = mazzo.Pesca(2);
                g.Foldato = false;
                g.PuntataAttuale = 0;
            }

            AggiornaGiocatori();
            pnlCarteComuni.Controls.Clear();
            MostraCarteComuni();
            //int daPescare = fase == 0 ? 3 : 1;
            //carteComuni.AddRange(mazzo.Pesca(daPescare));

        }
        private void btnPunta1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());
            Giocatore g = giocatori[index];

            int scommessa = 100;

            if (g.Foldato || g.Soldi <= 0) return;

            // Se non ha abbastanza soldi fa all-in
            if (g.Soldi <= scommessa)
            {
                piatto += g.Soldi;
                g.Soldi = 0;
            }
            else
            {
                piatto += scommessa;
                g.Soldi -= scommessa;
            }

            g.HaAgitoQuestoTurno = true;
            VerificaFineTurno();
            AggiornaGiocatori();
        }
        private void btnFold1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());
            Giocatore g = giocatori[index];

            g.Foldato = true;
            g.HaAgitoQuestoTurno = true;

            VerificaFineTurno();
            AggiornaGiocatori();
        }

        private void btnPunta2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());
            Giocatore g = giocatori[index];

            int scommessa = 100;

            if (g.Foldato || g.Soldi <= 0) return;

            // Se non ha abbastanza soldi fa all-in
            if (g.Soldi <= scommessa)
            {
                piatto += g.Soldi;
                g.Soldi = 0;
            }
            else
            {
                piatto += scommessa;
                g.Soldi -= scommessa;
            }

            g.HaAgitoQuestoTurno = true;
            VerificaFineTurno();
            AggiornaGiocatori();
        }

        private void btnFold2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());
            Giocatore g = giocatori[index];

            g.Foldato = true;
            g.HaAgitoQuestoTurno = true;

            VerificaFineTurno();
            AggiornaGiocatori();
        }

        private void btnPunta3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());
            Giocatore g = giocatori[index];

            int scommessa = 100;

            if (g.Foldato || g.Soldi <= 0) return;

            // Se non ha abbastanza soldi fa all-in
            if (g.Soldi <= scommessa)
            {
                piatto += g.Soldi;
                g.Soldi = 0;
            }
            else
            {
                piatto += scommessa;
                g.Soldi -= scommessa;
            }

            g.HaAgitoQuestoTurno = true;
            VerificaFineTurno();
            AggiornaGiocatori();
        }

        private void btnFold3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int index = int.Parse(btn.Tag.ToString());
            Giocatore g = giocatori[index];

            g.Foldato = true;
            g.HaAgitoQuestoTurno = true;

            VerificaFineTurno();
            AggiornaGiocatori();
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
            int daPescare = fase == 0 ? 3 : 1;
            carteComuni.AddRange(mazzo.Pesca(daPescare));
            fase++;

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
            if (fase == 3)
            {
                btnMostraVincitore.Visible = true;
                btnFaseSuccessiva.Enabled = false;
            }

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
        {
            for (int i = 0; i < giocatori.Count; i++)
            {
                Giocatore g = giocatori[i];

                Panel pannello = Controls.Find("pnlGiocatore" + (i + 1), true).FirstOrDefault() as Panel;
                if (pannello == null) continue;

                // Label con nome e soldi
                Label lblNomiSoldi = pannello.Controls.Find("lblNomiSoldi" + (i + 1), true).FirstOrDefault() as Label;
                if (lblNomiSoldi != null)
                {
                    if (g.Foldato)
                        lblNomiSoldi.Text = $"{g.Nome} - Foldato";
                    else
                        lblNomiSoldi.Text = $"{g.Nome} - ${g.Soldi}";
                }

                // Label con le carte
                Label lblCarte = pannello.Controls.Find("lblCarte" + (i + 1), true).FirstOrDefault() as Label;
                if (lblCarte != null)
                {
                    if (g.Foldato)
                        lblCarte.Text = "Carte: --";
                    else
                        lblCarte.Text = "Carte: " + string.Join(" ", g.Mano.Select(c => c.ToString()));
                }

                // Bottone "Punta"
                Button btnPunta = pannello.Controls.Find("btnPunta" + (i + 1), true).FirstOrDefault() as Button;
                if (btnPunta != null)
                {
                    btnPunta.Enabled = !g.Foldato && g.Soldi > 0;
                    btnPunta.Tag = i;
                }

                // Bottone "Fold"
                Button btnFold = pannello.Controls.Find("btnFold" + (i + 1), true).FirstOrDefault() as Button;
                if (btnFold != null)
                {
                    btnFold.Enabled = !g.Foldato;
                    btnFold.Tag = i;
                }
            }

            // Label del piatto (fuori dai pannelli)
            Label lblPiatto = Controls.Find("lblPiatto", true).FirstOrDefault() as Label;
            if (lblPiatto != null)
                lblPiatto.Text = $"Piatto: ${piatto}";
        }

        private void VerificaFineTurno()
        {
            if (giocatori.All(g => g.HaAgitoQuestoTurno || g.Foldato))
            {
                MostraCarteComuni();
                ResetAzioniTurno();
                AggiornaGiocatori();
            }
        }

        private void ResetAzioniTurno()
        {
            foreach (var g in giocatori)
                g.HaAgitoQuestoTurno = false;
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
                var nuovoForm = new PokerTexas(UtenteC.NomeU, UtenteC.NomeU2, UtenteC.NomeU3);
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
    public bool HaAgitoQuestoTurno { get; set; } = false;
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


