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
            //new IndovinaNumero().Show();
            //in produzione
        }

        private void PcBPoker_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Poker5().Show();
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
                var posizione = this.Location;
                var nuovoForm = new MenuLog();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
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
            else
            {
                var posizione = this.Location;
                var nuovoForm = new MenuLog();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }
    }
}
