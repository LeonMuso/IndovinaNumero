using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LogIn2 : Form
    {
        private TextBox txtUsername;
        private Button btnLogin;
        public LogIn2()
        {
            InitializeComponent();
            txtUsername = new TextBox
            {
                Location = new System.Drawing.Point(30, 30),
                Width = 150
            };
            btnLogin = new Button
            {
                Text = "Login",
                Location = new System.Drawing.Point(30, 70)
            };
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            txtUsername.Focus();
            AcceptButton = btnLogin;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string input = txtUsername.Text.Trim();
            if (Regex.IsMatch(input, @"^[A-Za-z_]+$"))
            {
                this.DialogResult = DialogResult.OK;
                UtenteC.NomeU2 = txtUsername.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Inserisci un nome valido");
                txtUsername.Clear();
                txtUsername.Focus();
            }

        }
    }
}
