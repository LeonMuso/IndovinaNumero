using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class IndovinaNumero : Form
    {
        Random r = new Random();
        const int min = 1;
        const int maxE = 50;
        const int maxM = 100;
        const int maxD = 500;
        int secondiPassati = 0;
        const int Victory = 100;
        int punteggio;
        string nomeGiocatore;
        string percorsoFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "punteggio.txt");

        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public IndovinaNumero()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            BtnNome.Visible = true;
            LblNome.Visible = true;
            BtnPlay.Visible = false;
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            BtnEasy.Visible = false;
            BtnMedium.Visible = false;
            BtnHard.Visible = false;
            TxBNumero.Visible = true;
            BtnVerificaNumero.Visible = true;
            LblMaxMin.Visible = true;
            LblTentativi.Visible = true;
            LblTimer.Visible = true;
            LblTimer.Text = "Tempo trascorso: 00:00";
            Timer.Start();
            global.Diff = 30;
            global.Tentativi = 10;
            global.TentativiMassimi = global.Tentativi;
            global.TempoMassimo = 120;
            global.Numero = r.Next(min, maxE + 1);
            global.Max = maxE;
            TxBNumero.Focus();
            //MessageBox.Show($"{global.Numero}");
        }

        private void BtnMedium_Click(object sender, EventArgs e)
        {
            BtnEasy.Visible = false;
            BtnMedium.Visible = false;
            BtnHard.Visible = false;
            TxBNumero.Visible = true;
            BtnVerificaNumero.Visible = true;
            LblMaxMin.Visible = true;
            LblTentativi.Visible = true;
            LblTimer.Visible = true;
            LblTimer.Text = "Tempo trascorso: 00:00";
            Timer.Start();
            global.Diff = 75;
            global.Tentativi = 7;
            global.TentativiMassimi = global.Tentativi;
            global.TempoMassimo = 90;
            global.Numero = r.Next(min, maxM + 1);
            global.Max = maxM;
            TxBNumero.Focus();
            //MessageBox.Show($"{global.Numero}");
        }

        private void BtnHard_Click(object sender, EventArgs e)
        {
            BtnEasy.Visible = false;
            BtnMedium.Visible = false;
            BtnHard.Visible = false;
            TxBNumero.Visible = true;
            BtnVerificaNumero.Visible = true;
            LblMaxMin.Visible = true;
            LblTentativi.Visible = true;
            LblTimer.Visible = true;
            LblTimer.Text = "Tempo trascorso: 00:00";
            Timer.Start();
            global.Diff = 150;
            global.Tentativi = 5;
            global.TentativiMassimi = global.Tentativi;
            global.TempoMassimo = 60;
            global.Numero = r.Next(min, maxD + 1);
            global.Max = maxD;
            TxBNumero.Focus();
            //MessageBox.Show($"{global.Numero}");
        }

        private void BtnVerificaNumero_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxBNumero.Text, out int o) && o > 0 && o <= global.Max)
            {

                if (o == global.Numero)
                {
                    Timer.Stop();
                    punteggio = Victory + (global.TempoMassimo - secondiPassati) + global.Diff + (global.Tentativi * 2);
                    string riga = $"{DateTime.Now:yyyy-MM-dd} - {nomeGiocatore} - Punteggio: {punteggio}" + Environment.NewLine;
                    try
                    {
                        File.AppendAllText(percorsoFile, riga);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Salvataggio su file non possibile" + ex.Message);
                    }

                    DialogResult risultato = MessageBox.Show("          --Punteggio--" +
                                                                "\n" + $"Vittoria +{Victory}" +
                                                                "\n" + $"Tempo rimanente +{global.TempoMassimo - secondiPassati}" +
                                                                "\n" + $"Difficoltà scelta +{global.Diff}" +
                                                                "\n" + $"Tentativi +{global.Tentativi * 2}" +
                                                                "\n" + $"Punteggio finale: {punteggio}" +
                                                                "\n" + "Vuoi rigiocare?", "Vittoria", MessageBoxButtons.YesNo);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Text = "";
                        LblTentativi.Visible = false;
                        LblTimer.Visible = false;
                        secondiPassati = 0;
                        TxBNumero.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }

                else if (o > global.Numero)
                {
                    LblMaxMin.Text = "Il numero è minore rispetto al tuo";
                    global.Tentativi--;
                    LblTentativi.Text = "Tentativi rimanenti: " + global.Tentativi.ToString();
                    TxBNumero.Clear();
                }
                else
                {
                    LblMaxMin.Text = "Il numero è maggiore rispetto al tuo";
                    global.Tentativi--;
                    LblTentativi.Text = "Tentativi rimanenti: " + global.Tentativi.ToString();
                    TxBNumero.Clear();
                }
                if (global.Tentativi == 0)
                {
                    DialogResult risultato = MessageBox.Show($"Hai perso per aver terminato i {global.TentativiMassimi} tentativi" +
                                                              "\n" + $"Il numero era {global.Numero}" +
                                                              "\n" + "Vuoi rigiocare?",
                                                              "Sconfitta", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Text = "";
                        LblTentativi.Visible = false;
                        LblTimer.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
                        TxBNumero.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Riprova mettendo un numero valido");
                TxBNumero.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = BtnVerificaNumero;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondiPassati++;
            TimeSpan tempo = TimeSpan.FromSeconds(secondiPassati);
            LblTimer.Text = $"Tempo trascorso: {tempo.Minutes:D2}:{tempo.Seconds:D2}";
            if (global.TempoMassimo == 120)
            {
                if (secondiPassati == 60)
                {
                    synthesizer.SpeakAsync($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == 90)
                {
                    synthesizer.SpeakAsync($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == global.TempoMassimo)
                {
                    DialogResult risultato = MessageBox.Show($"Hai perso perchè è scaduto il tempo" + "\n" + "Vuoi rigiocare?", "Sconfitta", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Text = "";
                        LblTentativi.Visible = false;
                        LblTimer.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
                        TxBNumero.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            else if (global.TempoMassimo == 90)
            {
                if (secondiPassati == 30)
                {
                    synthesizer.SpeakAsync($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == 60)
                {
                    synthesizer.SpeakAsync($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == global.TempoMassimo)
                {
                    DialogResult risultato = MessageBox.Show($"Hai perso perchè è scaduto il tempo" + "\n" + "Vuoi rigiocare?", "Sconfitta", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Text = "";
                        LblTentativi.Visible = false;
                        LblTimer.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
                        TxBNumero.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
            else if (global.TempoMassimo == 60)
            {
                if (secondiPassati == 15)
                {
                    synthesizer.SpeakAsync($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == 30)
                {
                    synthesizer.SpeakAsync($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == global.TempoMassimo)
                {
                    DialogResult risultato = MessageBox.Show($"Hai perso perchè è scaduto il tempo" + "\n" + "Vuoi rigiocare?", "Sconfitta", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Text = "";
                        LblTentativi.Visible = false;
                        LblTimer.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
                        TxBNumero.Clear();
                    }
                    else
                    {
                        Close();
                    }
                }
            }


        }

        private void BtnNome_Click(object sender, EventArgs e)
        {
            do
            {
                nomeGiocatore = Interaction.InputBox("inserisci il tuo nome", "nome giocatore").Trim();
                if (string.IsNullOrEmpty(nomeGiocatore) || nomeGiocatore.Any(char.IsDigit))
                {
                    MessageBox.Show("Nome non valido");
                }
            } while (string.IsNullOrEmpty(nomeGiocatore) || nomeGiocatore.Any(char.IsDigit));
            BtnEasy.Visible = true;
            BtnMedium.Visible = true;
            BtnHard.Visible = true;
            BtnNome.Visible = false;
            LblNome.Visible = false;
        }

        private void IndovinaNumero_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire da indovina il numero?",
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
                var nuovoForm = new IndovinaNumero();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }
    }
    public static class global
    {
        public static int Tentativi;
        public static int TentativiMassimi;
        public static int TempoMassimo;
        public static int Numero;
        public static int Max;
        public static int Diff;
    }
}
