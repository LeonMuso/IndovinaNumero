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
    public partial class Nim : Form
    {
        private int[] righe = { 1, 3, 5, 7, 9 };
        private List<List<Label>> fiammiferiPerRiga = new List<List<Label>>();
        private int giocatoreAttivo = 1;
        int rigaSelezionata = -1;
        HashSet<Label> fiammiferiSelezionati = new HashSet<Label>();
        const int victory = 150;
        int punteggio = 0;
        public Nim(string p1, string p2)
        {
            InitializeComponent();
        }

        private void InizializzaGioco()
        {
            pnlGioco.Controls.Clear();
            fiammiferiPerRiga.Clear();
            if (giocatoreAttivo == 1)
            {
                lblTurno.Text = $"Turno del Giocatore {UtenteC.NomeU}";
            }
            else if (giocatoreAttivo == 2)
            {
                lblTurno.Text = $"Turno del Giocatore {UtenteC.NomeU2}";
            }

            foreach (int count in righe)
            {
                var rigaPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    Margin = new Padding(0, 10, 0, 10),
                    Tag = fiammiferiPerRiga.Count // indice della riga
                };

                List<Label> fiammiferiRiga = new List<Label>();

                for (int i = 0; i < count; i++)
                {
                    var f = new Label
                    {
                        Width = 25,
                        Height = 60,
                        BackColor = Color.OrangeRed,
                        Text = "|",
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Consolas", 16),
                        Margin = new Padding(5, 0, 5, 0),
                        Tag = true // visibile
                    };
                    f.Click += Fiammifero_Click;
                    fiammiferiRiga.Add(f);
                    rigaPanel.Controls.Add(f);
                }

                rigaPanel.Click += RigaPanel_Click;

                fiammiferiPerRiga.Add(fiammiferiRiga);
                pnlGioco.Controls.Add(rigaPanel);
            }
        }

        private void RigaPanel_Click(object sender, EventArgs e)
        {
            if (sender is FlowLayoutPanel panel)
                rigaSelezionata = (int)panel.Tag;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            InizializzaGioco();
            lblTurno.Visible = true;
            lblTitolo.Visible = false;
            pnlGioco.Visible = true;
            btnConferma.Visible = true;
        }

        private void Fiammifero_Click(object sender, EventArgs e)
        {
            Label f = sender as Label;

            // Trova la riga a cui appartiene il fiammifero
            for (int i = 0; i < fiammiferiPerRiga.Count; i++)
            {
                if (fiammiferiPerRiga[i].Contains(f))
                {
                    rigaSelezionata = i;
                    break;
                }
            }

            if (!f.Visible) return;

            // Alterna selezione/deselezione
            if (fiammiferiSelezionati.Contains(f))
            {
                fiammiferiSelezionati.Remove(f);
                f.BackColor = Color.OrangeRed;
            }
            else
            {
                fiammiferiSelezionati.Add(f);
                f.BackColor = Color.Gold;
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            if (rigaSelezionata == -1 || fiammiferiSelezionati.Count == 0)
            {
                MessageBox.Show("Seleziona una riga e dei fiammiferi da togliere.");
                return;
            }

            // Controllo: tutti i fiammiferi selezionati devono essere nella stessa riga
            var righeSelezionate = fiammiferiSelezionati
                .Select(f => fiammiferiPerRiga.FindIndex(r => r.Contains(f)))
                .Distinct()
                .ToList();

            if (righeSelezionate.Count > 1)
            {
                MessageBox.Show("Puoi togliere fiammiferi solo da una riga per turno!");
                return;
            }

            // (Opzionale) Controllo fiammiferi consecutivi
            var riga = righeSelezionate.First();
            var fiammiferiVisibili = fiammiferiPerRiga[riga].Where(f => f.Visible).ToList();
            var indiciSelezionati = fiammiferiSelezionati
                .Select(f => fiammiferiVisibili.IndexOf(f))
                .OrderBy(i => i)
                .ToList();

            for (int i = 1; i < indiciSelezionati.Count; i++)
            {
                if (indiciSelezionati[i] != indiciSelezionati[i - 1] + 1)
                {
                    MessageBox.Show("Devi selezionare fiammiferi consecutivi!");
                    return;
                }
            }

            // Rimuovi fiammiferi selezionati
            foreach (Label f in fiammiferiSelezionati)
            {
                f.Visible = false;
            }

            // Reset
            fiammiferiSelezionati.Clear();
            rigaSelezionata = -1;

            // Controlla se il gioco è finito
            if (fiammiferiPerRiga.SelectMany(r => r).All(f => !f.Visible))
            {
                punteggio = victory;
                if (giocatoreAttivo == 1)
                {
                    MessageBox.Show($"Il Giocatore {UtenteC.NomeU} ha vinto!");
                    string gioco = "Nim";
                    string utente = UtenteC.NomeU;
                    int punteggioAttuale = GestionePunteggi.OttieniPunteggio(gioco, utente);
                    if (!(punteggioAttuale > punteggio))
                    {
                        int nuovoPunteggio = punteggio;
                        GestionePunteggi.AggiornaPunteggio(gioco, utente, nuovoPunteggio);
                    }
                }
                else if (giocatoreAttivo == 2)
                {
                    MessageBox.Show($"Il Giocatore {UtenteC.NomeU2} ha vinto!");
                    string gioco = "Nim";
                    string utente = UtenteC.NomeU2;
                    int punteggioAttuale = GestionePunteggi.OttieniPunteggio(gioco, utente);
                    if (!(punteggioAttuale > punteggio))
                    {
                        int nuovoPunteggio = punteggio;
                        GestionePunteggi.AggiornaPunteggio(gioco, utente, nuovoPunteggio);
                    }
                }


                DialogResult risultato = MessageBox.Show($"Vittoria +{victory}" +
                                                          "\n" + "Vuoi rigiocare?", "Vittoria", MessageBoxButtons.YesNo);
                if (risultato == DialogResult.Yes)
                {

                    InizializzaGioco();
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            // Cambio turno
            giocatoreAttivo = giocatoreAttivo == 1 ? 2 : 1;
            if (giocatoreAttivo == 1)
            {
                lblTurno.Text = $"Turno del Giocatore {UtenteC.NomeU}";
            }
            else if (giocatoreAttivo == 2)
            {
                lblTurno.Text = $"Turno del Giocatore {UtenteC.NomeU2}";
            }

        }

        private void Nim_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire dal nim?",
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
                var nuovoForm = new Nim(UtenteC.NomeU, UtenteC.NomeU2);
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }

        private void BtnClassifica_Click(object sender, EventArgs e)
        {
            new Classifica("Nim").Show();
        }
    }
}
