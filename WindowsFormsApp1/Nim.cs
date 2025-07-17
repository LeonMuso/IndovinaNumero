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
        private int oggetti;
        private bool turnoGiocatore1;

        public Nim()
        {
            InitializeComponent();
            numOggettiIniziali.Minimum = 5;
            numOggettiIniziali.Maximum = 100;
            numOggettiIniziali.Value = 21;
            btnPrendi1.Click += (s, e) => Prendi(1);
            btnPrendi2.Click += (s, e) => Prendi(2);
            btnPrendi3.Click += (s, e) => Prendi(3);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            NuovaPartita();
        }

        private void NuovaPartita()
        {
            oggetti = (int)numOggettiIniziali.Value;
            turnoGiocatore1 = true;
            AggiornaUI();
        }

        private void Prendi(int quanti)
        {
            if (quanti <= 0 || quanti > 3) return;
            if (oggetti - quanti < 0) return;

            oggetti -= quanti;
            AggiornaUI();

            if (oggetti == 0)
            {
                string vincitore = turnoGiocatore1 ? "Giocatore 1" : "Giocatore 2";
                MessageBox.Show($"{vincitore} ha vinto!", "Fine partita");
                DisabilitaBottoni();
                return;
            }

            turnoGiocatore1 = !turnoGiocatore1;
            AggiornaUI();
        }

        private void AggiornaUI()
        {
            lblOggetti.Text = $"Oggetti rimasti: {oggetti}";
            lblTurno.Text = $"Turno: {(turnoGiocatore1 ? "Giocatore 1" : "Giocatore 2")}";

            btnPrendi1.Enabled = oggetti >= 1;
            btnPrendi2.Enabled = oggetti >= 2;
            btnPrendi3.Enabled = oggetti >= 3;
        }

        private void DisabilitaBottoni()
        {
            btnPrendi1.Enabled = btnPrendi2.Enabled = btnPrendi3.Enabled = false;
        }
    }
}
