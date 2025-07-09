using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LogIn2 : Form
    {
        private Button btnLogin;
        private string utentiPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UtentiRecenti.json");
        public LogIn2()
        {
            InitializeComponent();
            CaricaUtentiRecenti();
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
                SalvaNomeUtente(input);
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

        private void lstNomiRecenti_Click(object sender, EventArgs e)
        {
            if (lstNomiRecenti.SelectedItem != null)
                txtUsername.Text = lstNomiRecenti.SelectedItem.ToString();
        }
        private void CaricaUtentiRecenti()
        {
            if (!File.Exists(utentiPath))
                return;

            var json = File.ReadAllText(utentiPath);
            var nomi = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();

            foreach (var nome in nomi)
                lstNomiRecenti.Items.Add(nome);
        }


        private void SalvaNomeUtente(string nome)
        {
            var nomi = new List<string>();

            if (File.Exists(utentiPath))
            {
                nomi = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(utentiPath)) ?? new List<string>();
            }

            if (!nomi.Contains(nome))
            {
                nomi.Add(nome);
                File.WriteAllText(utentiPath, JsonConvert.SerializeObject(nomi, Formatting.Indented));
            }
        }
    }
}
