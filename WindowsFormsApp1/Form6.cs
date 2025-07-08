using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {
        private TextBox txtUsername;
        private Button btnLogin;
        public LogIn()
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
                Location = new System.Drawing.Point(30,70)
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
            if (Regex.IsMatch(input,@"^[A-Za-z_]+$"))
            {
                UtenteC.NomeU = txtUsername.Text;
                this.Hide();
                new Form5().Show();
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
