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
using Newtonsoft.Json;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {
        private Button btnLogin;
        private readonly string utentiPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UtentiRecenti.json");
        public LogIn()
        {
            InitializeComponent();
            CaricaUtenti();
            btnLogin = new Button
            {
                Text = "Login",
                Location = new System.Drawing.Point(150, 100)
            };
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(btnLogin);
            AcceptButton = btnLogin;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string nome = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (!Regex.IsMatch(nome, @"^[a-zA-Z_]+$"))
            {
                MessageBox.Show("Il nome utente può contenere solo lettere e underscore (_)");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Inserisci una password.");
                return;
            }

            var utenti = CaricaUtenti();
            var utenteEsistente = utenti.FirstOrDefault(u => u.Nome == nome);

            if (utenteEsistente != null)
            {
                if (utenteEsistente.Password != password)
                {
                    MessageBox.Show("Password errata.");
                    return;
                }
            }
            else
            {
                AggiungiNuovoUtente(nome, password);
            }
            UtenteC.NomeU = nome;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void lstNomiRecenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selezionato = lstNomiRecenti.SelectedItem.ToString();
            var utenti = CaricaUtenti();
            var trovato = utenti.FirstOrDefault(u => u.Nome == selezionato);
            if (trovato != null)
            {
                txtUsername.Text = trovato.Nome;
                //txtPassword.Text = trovato.Password;
            }
        }

        private List<Utente> CaricaUtenti()
        {
            if (!File.Exists(utentiPath))
                return new List<Utente>();

            string json = File.ReadAllText(utentiPath);
            return JsonConvert.DeserializeObject<List<Utente>>(json) ?? new List<Utente>();
        }


        private void AggiungiNuovoUtente(string nome, string password)
        {
            var utenti = CaricaUtenti();
            utenti.Add(new Utente { Nome = nome, Password = password });
            string json = JsonConvert.SerializeObject(utenti, Formatting.Indented);
            File.WriteAllText(utentiPath, json);
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            var utenti = CaricaUtenti();
            lstNomiRecenti.Items.Clear();
            lstNomiRecenti.Items.AddRange(utenti.Select(u => u.Nome).ToArray());
        }
    }
    public class Utente
    {
        public string Nome { get; set; }
        public string Password { get; set; }

    }
}