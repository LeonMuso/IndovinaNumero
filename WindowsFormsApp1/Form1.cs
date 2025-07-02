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
    public partial class Form1 : Form
    {
        Random r = new Random();
        const int min = 1;
        const int maxE = 50;
        const int maxM = 100;
        const int maxD = 500;
        int secondiPassati = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            BtnPlay.Visible = false;
            BtnEasy.Visible = true;
            BtnMedium.Visible = true;
            BtnHard.Visible = true;
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
            Timer.Start();
            global.Tentativi = 10;
            global.TentativiMassimi = global.Tentativi;
            global.TempoMassimo = 120;
            global.Numero = r.Next(min, maxE + 1);
            global.max = maxE;
            TxBNumero.Focus();
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
            Timer.Start();
            global.Tentativi = 7;
            global.TentativiMassimi = global.Tentativi;
            global.TempoMassimo = 90;
            global.Numero = r.Next(min, maxM + 1);
            global.max = maxM;
            TxBNumero.Focus();
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
            Timer.Start();
            global.Tentativi = 5;
            global.TentativiMassimi = global.Tentativi;
            global.TempoMassimo = 60;
            global.Numero = r.Next(min, maxD + 1);
            global.max = maxD;
            TxBNumero.Focus();
        }

        private void BtnVerificaNumero_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TxBNumero.Text, out int o) && o > 0 && o < global.max)
            {
                if (o == global.Numero)
                {
                    DialogResult risultato = MessageBox.Show("Hai vinto!!!" + "\n" + "Vuoi rigiocare?", "Vittoria", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Visible = false;
                        Timer.Stop();
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
                    DialogResult risultato = MessageBox.Show($"Hai perso per aver terminato i {global.TentativiMassimi} tentativi" + "\n" + "Vuoi rigiocare?", "Sconfitta", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (risultato == DialogResult.Yes)
                    {
                        BtnEasy.Visible = true;
                        BtnMedium.Visible = true;
                        BtnHard.Visible = true;
                        TxBNumero.Visible = false;
                        BtnVerificaNumero.Visible = false;
                        LblMaxMin.Text = "";
                        LblMaxMin.Visible = false;
                        LblTentativi.Visible = false;
                        Timer.Stop();
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
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = BtnVerificaNumero;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondiPassati++;
            if (global.TempoMassimo == 120)
            {
                if (secondiPassati == 60)
                {
                    MessageBox.Show($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == 90)
                {
                    MessageBox.Show($"passati {secondiPassati} secondi");
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
                        LblTentativi.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
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
                    MessageBox.Show($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == 60)
                {
                    MessageBox.Show($"passati {secondiPassati} secondi");
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
                        LblTentativi.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
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
                    MessageBox.Show($"passati {secondiPassati} secondi");
                }
                else if (secondiPassati == 30)
                {
                    MessageBox.Show($"passati {secondiPassati} secondi");
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
                        LblTentativi.Visible = false;
                        Timer.Stop();
                        secondiPassati = 0;
                    }
                    else
                    {
                        Close();
                    }
                }
            }


        }
    }
    public static class global
    {
        public static int Tentativi;
        public static int TentativiMassimi;
        public static int TempoMassimo;
        public static int Numero;
        public static int max;
    }
}
