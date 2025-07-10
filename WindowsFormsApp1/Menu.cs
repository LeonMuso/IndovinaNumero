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
    public partial class MenuLog : Form
    {
        public MenuLog()
        {
            InitializeComponent();
            LblUtente.Text = "Benvenuto " + UtenteC.NomeU;
        }

        private void PcBNumero_Click(object sender, EventArgs e)
        {
            this.Hide();
            new IndovinaNumero().Show();
        }

        private void PcBLucchetto_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SbloccaLucchetto().Show();
        }

        private void PcBCampoMinato_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CampoMinato().Show();
        }

        private void PcBBOMB_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //new Form1().Show();
        }

        private void PcBPoker_Click(object sender, EventArgs e)
        {
            var login2 = new LogIn2();
            if (login2.ShowDialog() == DialogResult.OK)
            {
                string nome1 = UtenteC.NomeU;
                string nome2 = UtenteC.NomeU2;
                var poker = new Poker5(nome1,nome2);
                poker.Show();
                this.Hide();
            }
        }

        private void MenuLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire dal menu?",
                                                      "Uscita",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Stop);
            if (risultato == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BtnEsci_Click(object sender, EventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire dal menu?",
                                                      "Uscita",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Stop);
            if (risultato == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnClassifica_Click(object sender, EventArgs e)
        {
            new Classifica().Show();
        }
    }
}
