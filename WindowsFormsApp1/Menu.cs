using SudokuWinForms;
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
            if (UtenteC.NomeU != null)
            {
                LblUtente.Visible = true;
                LblUtente.Text = "Benvenuto " + UtenteC.NomeU;
                BtnLogIn.Visible = false;
            }
        }

        private void PcBNumero_Click(object sender, EventArgs e)
        {
            if (UtenteC.NomeU != null)
            {
                this.Hide();
                new IndovinaNumero().Show();
            }
            else
            {
                MessageBox.Show("Fai prima il login", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PcBLucchetto_Click(object sender, EventArgs e)
        {
            if (UtenteC.NomeU != null)
            {
                this.Hide();
                new SbloccaLucchetto().Show();
            }
            else
            {
                MessageBox.Show("Fai prima il login", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PcBCampoMinato_Click(object sender, EventArgs e)
        {
            if (UtenteC.NomeU != null)
            {
                this.Hide();
                new CampoMinato().Show();
            }
            else
            {
                MessageBox.Show("Fai prima il login", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PcBBOMB_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //new Form1().Show();
        }

        private void PcBPoker_Click(object sender, EventArgs e)
        {
            if (UtenteC.NomeU != null)
            {
                var login2 = new LogIn2();
                if (login2.ShowDialog() == DialogResult.OK)
                {
                    string nome1 = UtenteC.NomeU;
                    string nome2 = UtenteC.NomeU2;
                    var poker = new Poker5(nome1, nome2);
                    poker.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Fai prima il login", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            if (logIn.ShowDialog() == DialogResult.OK)
            {
                BtnLogIn.Visible = false;
                LblUtente.Visible = true;
                LblUtente.Text = "Benvenuto " + UtenteC.NomeU;
            }
        }

        private void PcBSudoku_Click(object sender, EventArgs e)
        {
            if (UtenteC.NomeU != null)
            {
                this.Hide();
                new Sudoku().Show();
            }
            else
            {
                MessageBox.Show("Fai prima il login", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
