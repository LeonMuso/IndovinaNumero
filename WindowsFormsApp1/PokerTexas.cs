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
using Newtonsoft.Json;
using System.IO;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class PokerTexas : Form
    {
        private List<Giocatore> giocatori = new List<Giocatore>();
        private HashSet<string> giocatoriProntiPerFase = new HashSet<string>();
        private mazzo mazzo;
        private List<carta> carteComuni = new List<carta>();
        private int fase = 0;
        private int piatto = 0;
        const int puntiVittoria = 150;
        int giocatoreCorrente = 0;
        int puntataMassima = 0;
        int clickFase = 0;
        public PokerTexas(string p1, string p2, string p3)
        {
            InitializeComponent();
            LblUtente.Text = UtenteC.NomeU;

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
            AggiornaStatoBottoniTurno();
        }

        private void btnPunta1_Click(object sender, EventArgs e)
        {
            Giocatore g = giocatori[giocatoreCorrente];

            if (g.Foldato || g.Soldi <= 0) return;

            Puntata fp = new Puntata(g.Soldi);
            if (fp.ShowDialog() == DialogResult.OK)
            {
                int puntata = fp.ImportoPuntata;
                int differenza = puntata - g.PuntataAttuale;

                // ❗ Non può puntare meno della puntataMassima (tranne all-in)
                if (puntata < puntataMassima && puntata != g.Soldi)
                {
                    MessageBox.Show($"Devi puntare almeno {puntataMassima} oppure fare all-in.");
                    return;
                }

                // Aggiorna la puntata
                g.Soldi -= differenza;
                g.PuntataAttuale = puntata;
                g.HaAgitoQuestoTurno = true;
                piatto += differenza;

                // Se questa è la nuova puntata massima, aggiorna e resetta gli altri
                if (puntata > puntataMassima)
                {
                    puntataMassima = puntata;
                    foreach (var gioc in giocatori)
                        if (!gioc.Foldato)
                            gioc.HaAgitoQuestoTurno = false;

                    g.HaAgitoQuestoTurno = true;
                }

                AvanzaTurno();
                AggiornaGiocatori();
                AggiornaStatoBottoniTurno();
            }
        }

        private void btnFold1_Click(object sender, EventArgs e)
        {

            Giocatore g = giocatori[giocatoreCorrente];
            g.Foldato = true;
            g.HaAgitoQuestoTurno = true;

            AvanzaTurno();
            AggiornaGiocatori();
            AggiornaStatoBottoniTurno();
        }

        private void btnPunta2_Click(object sender, EventArgs e)
        {
            Giocatore g = giocatori[giocatoreCorrente];

            if (g.Foldato || g.Soldi <= 0) return;

            Puntata fp = new Puntata(g.Soldi);
            if (fp.ShowDialog() == DialogResult.OK)
            {
                int puntata = fp.ImportoPuntata;
                int differenza = puntata - g.PuntataAttuale;

                // ❗ Non può puntare meno della puntataMassima (tranne all-in)
                if (puntata < puntataMassima && puntata != g.Soldi)
                {
                    MessageBox.Show($"Devi puntare almeno {puntataMassima} oppure fare all-in.");
                    return;
                }

                // Aggiorna la puntata
                g.Soldi -= differenza;
                g.PuntataAttuale = puntata;
                g.HaAgitoQuestoTurno = true;
                piatto += differenza;

                // Se questa è la nuova puntata massima, aggiorna e resetta gli altri
                if (puntata > puntataMassima)
                {
                    puntataMassima = puntata;
                    foreach (var gioc in giocatori)
                        if (!gioc.Foldato)
                            gioc.HaAgitoQuestoTurno = false;

                    g.HaAgitoQuestoTurno = true;
                }

                AvanzaTurno();
                AggiornaGiocatori();
                AggiornaStatoBottoniTurno();
            }
        }

        private void btnFold2_Click(object sender, EventArgs e)
        {
            Giocatore g = giocatori[giocatoreCorrente];
            g.Foldato = true;
            g.HaAgitoQuestoTurno = true;

            AvanzaTurno();
            AggiornaGiocatori();
            AggiornaStatoBottoniTurno();
        }

        private void btnPunta3_Click(object sender, EventArgs e)
        {
            Giocatore g = giocatori[giocatoreCorrente];

            if (g.Foldato || g.Soldi <= 0) return;

            Puntata fp = new Puntata(g.Soldi);
            if (fp.ShowDialog() == DialogResult.OK)
            {
                int puntata = fp.ImportoPuntata;
                int differenza = puntata - g.PuntataAttuale;

                // ❗ Non può puntare meno della puntataMassima (tranne all-in)
                if (puntata < puntataMassima && puntata != g.Soldi)
                {
                    MessageBox.Show($"Devi puntare almeno {puntataMassima} oppure fare all-in.");
                    return;
                }

                // Aggiorna la puntata
                g.Soldi -= differenza;
                g.PuntataAttuale = puntata;
                g.HaAgitoQuestoTurno = true;
                piatto += differenza;

                // Se questa è la nuova puntata massima, aggiorna e resetta gli altri
                if (puntata > puntataMassima)
                {
                    puntataMassima = puntata;
                    foreach (var gioc in giocatori)
                        if (!gioc.Foldato)
                            gioc.HaAgitoQuestoTurno = false;

                    g.HaAgitoQuestoTurno = true;
                }

                AvanzaTurno();
                AggiornaGiocatori();
                AggiornaStatoBottoniTurno();
            }
        }

        private void btnFold3_Click(object sender, EventArgs e)
        {
            Giocatore g = giocatori[giocatoreCorrente];
            g.Foldato = true;
            g.HaAgitoQuestoTurno = true;

            AvanzaTurno();
            AggiornaGiocatori();
            AggiornaStatoBottoniTurno();
        }

        private void btnMostraVincitore_Click(object sender, EventArgs e)
        {
            MostraVincitore();
            btnStart_Click(sender, e);
            btnMostraVincitore.Visible = false;
        }

        private void PassaFaseSuccessiva()
        {
            MostraCarteComuni();
        }

        private void btnFaseSuccessiva_Click(object sender, EventArgs e)
        {
            Giocatore g = giocatori[giocatoreCorrente];

            // Se ha già cliccato, lo blocco
            if (giocatoriProntiPerFase.Contains(g.Nome))
            {
                MessageBox.Show("Hai già confermato per la fase successiva oppure devi puntare uguale agli altri");
                giocatoriProntiPerFase.Clear();
                return;
            }

            // Controllo se le puntate sono tutte uguali tra i giocatori ancora in gioco
            var puntateAttive = giocatori
                .Where(x => !x.Foldato && x.Soldi > 0)
                .Select(x => x.PuntataAttuale)
                .Distinct()
                .ToList();

            if (puntateAttive.Count > 1)
            {
                MessageBox.Show("Le puntate non sono ancora uguali. Non puoi proseguire.");
                giocatoriProntiPerFase.Clear();
                return;
            }

            // Se le puntate sono tutte uguali, segna il giocatore come pronto
            giocatoriProntiPerFase.Add(g.Nome);
            g.HaAgitoQuestoTurno = true;

            // Verifica se tutti i giocatori attivi hanno cliccato
            int attivi = giocatori.Count(x => !x.Foldato && x.Soldi > 0);
            int pronti = giocatoriProntiPerFase.Count;

            if (pronti == attivi)
            {
                giocatoriProntiPerFase.Clear();
                PassaFaseSuccessiva();
                giocatoreCorrente = 0;
                foreach (var gioc in giocatori)
                {
                    gioc.HaAgitoQuestoTurno = false;
                    gioc.PuntataAttuale = 0;
                }

                //AvanzaTurno(); // riparte il ciclo dei turni
            }
            else
            {
                AvanzaTurno(); // passa al prossimo giocatore
            }

            AggiornaStatoBottoniTurno();
        }

        private void MostraCarteComuni()
        {
            int daPescare = fase == 0 ? 3 : 1;
            carteComuni.AddRange(mazzo.Pesca(daPescare));
            fase++;

            pnlCarteComuni.Controls.Clear();
            for (int i = 0; i < carteComuni.Count; i++)
            {
                int x = 0;
                foreach (var carta in carteComuni)
                {
                    Label lblCarta = new Label
                    {
                        Width = 50,
                        Height = 70,
                        Left = x,
                        Top = 10,
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = $"{carta.Valore}\n{carta.Simbolo}",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = carta.Colore,
                        BackColor = Color.White
                    };
                    pnlCarteComuni.Controls.Add(lblCarta);
                    x += 60;
                }
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
                int punteggioC = puntiVittoria + piatto / 2;
                string gioco = "Texas Holdem";
                string utente = vincitore.Nome;
                int punteggioAttuale = GestionePunteggi.OttieniPunteggio(gioco, utente);
                if (!(punteggioAttuale > punteggioC))
                {
                    int nuovoPunteggio = punteggioC;
                    GestionePunteggi.AggiornaPunteggio(gioco, utente, nuovoPunteggio);
                }
                MessageBox.Show($"Vince {vincitore.Nome} con punteggio {punteggioMax}! Ha vinto ${piatto}.", "Risultato");
                giocatoreCorrente = 0;
                puntataMassima = 0;
                giocatori[0].PuntataAttuale = 0;
                giocatori[1].PuntataAttuale = 0;
                giocatori[2].PuntataAttuale = 0;
                giocatori[0].HaAgitoQuestoTurno = false;
                giocatori[1].HaAgitoQuestoTurno = false;
                giocatori[2].HaAgitoQuestoTurno = false;
            }
            else
            {
                MessageBox.Show("Tutti hanno foldato! Nessun vincitore.");
                giocatoreCorrente = 0;
                puntataMassima = 0;
                giocatori[0].PuntataAttuale = 0;
                giocatori[1].PuntataAttuale = 0;
                giocatori[2].PuntataAttuale = 0;
                giocatori[0].HaAgitoQuestoTurno = false;
                giocatori[1].HaAgitoQuestoTurno = false;
                giocatori[2].HaAgitoQuestoTurno = false;
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

                if (g.Foldato)
                {
                    Label lblFold = new Label
                    {
                        Text = "Foldato",
                        AutoSize = true,
                        Top = 30,
                        Left = 0,
                        ForeColor = Color.Gray,
                        Font = new Font("Segoe UI", 9, FontStyle.Italic)
                    };
                    pannello.Controls.Add(lblFold);
                    continue;
                }

                // Mostra le carte
                int x = 0;
                foreach (var carta in g.Mano)
                {
                    Label lblCarta = new Label
                    {
                        Width = 50,
                        Height = 70,
                        Left = x,
                        Top = 30,
                        BorderStyle = BorderStyle.FixedSingle,
                        Text = $"{carta.Valore}\n{carta.Simbolo}",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = carta.Colore,
                        BackColor = Color.White
                    };
                    pannello.Controls.Add(lblCarta);
                    x += 60;
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

        private void AvanzaTurno()
        {
            int tentativi = 0;

            do
            {
                giocatoreCorrente = (giocatoreCorrente + 1) % 3;
                tentativi++;
                if (tentativi > 3)
                {
                    break;
                }
            }
            while ((giocatori[giocatoreCorrente].Foldato || giocatori[giocatoreCorrente].Soldi <= 0 || giocatori[giocatoreCorrente].HaAgitoQuestoTurno));
            bool tuttiHannoAgito = giocatori.Where(g => !g.Foldato && g.Soldi > 0).All(g => g.HaAgitoQuestoTurno);

            if (tuttiHannoAgito)
            {
                if (fase != 3)
                {
                    PassaFaseSuccessiva();
                    giocatoreCorrente = 0;
                    puntataMassima = 0;
                    giocatori[0].PuntataAttuale = 0;
                    giocatori[1].PuntataAttuale = 0;
                    giocatori[2].PuntataAttuale = 0;
                    giocatori[0].HaAgitoQuestoTurno = false;
                    giocatori[1].HaAgitoQuestoTurno = false;
                    giocatori[2].HaAgitoQuestoTurno = false;
                }
            }
            AggiornaStatoBottoniTurno();
        }

        private void AggiornaStatoBottoniTurno()
        {
            for (int i = 0; i < 3; i++)
            {
                bool turnoAttivo = (i == giocatoreCorrente);
                Giocatore g = giocatori[i];

                Button btnPunta = (Button)this.Controls.Find("btnPunta" + (i + 1), true).FirstOrDefault();
                Button btnFold = (Button)this.Controls.Find("btnFold" + (i + 1), true).FirstOrDefault();

                if (btnPunta != null)
                    btnPunta.Enabled = turnoAttivo && !g.Foldato && g.Soldi > 0;

                if (btnFold != null)
                    btnFold.Enabled = turnoAttivo && !g.Foldato;
            }
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

        private void BtnClassifica_Click(object sender, EventArgs e)
        {
            new Classifica("Texas Holdem").Show();
        }

    }

    public class carta
    {
        public string GetSimbolo(string seme)
        {
            switch (seme)
            {
                case "Cuori":
                    return "♥";
                case "Quadri":
                    return "♦";
                case "Picche":
                    return "♠";
                case "Fiori":
                    return "♣";
                default:
                    return "?";
            }
        }

        public Color GetColore(string seme)
        {
            switch (seme)
            {
                case "Cuori":
                case "Quadri":
                    return Color.Red;
                case "Picche":
                case "Fiori":
                    return Color.Black;
                default:
                    return Color.Black;
            }
        }
        public string Seme { get; set; }
        public string Valore { get; set; }
        public string Simbolo => GetSimbolo(Seme);
        public Color Colore => GetColore(Seme);
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
}


