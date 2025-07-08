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
    public partial class SbloccaLucchetto : Form
    {
        public SbloccaLucchetto()
        {
            InitializeComponent();
        }

        int[] codiceSegreto;
        int rigaCorrente = 0;
        List<NumericUpDown[]> righeNumeri = new List<NumericUpDown[]>();
        const int maxTentativi = 10;

        private void Form2_Load(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            codiceSegreto = new int[4];
            for (int i = 0; i < 4; i++)
                codiceSegreto[i] = rnd.Next(0, 10);

            
            for (int i = 0; i < maxTentativi; i++)
            {
                NumericUpDown[] riga = new NumericUpDown[4];
                for (int j = 0; j < 4; j++)
                {
                    string nome = $"num{i}{j}";
                    var controllo = Controls.Find(nome, true).FirstOrDefault() as NumericUpDown;
                    if (controllo != null)
                    {
                        controllo.Minimum = 0;
                        controllo.Maximum = 9;
                        controllo.Enabled = (i == 0);
                        riga[j] = controllo;
                    }
                    else
                    {
                        MessageBox.Show($"controlla non trovato: {nome}");
                    }
                }
                righeNumeri.Add(riga);
            }

            LblTentativi.Text = $"Tentativi rimanenti: {maxTentativi}";
        }

        private void BtnVerifica_Click(object sender, EventArgs e)
        {
            if (rigaCorrente >= maxTentativi)
                return;

            var riga = righeNumeri[rigaCorrente];
            int corrette = 0;

            for (int i = 0; i < 4; i++)
            {
                if ((int)riga[i].Value == codiceSegreto[i])
                    corrette++;
                riga[i].Enabled = false;
            }

            LblCorrette.Text = $"Cifre corrette (posizione giusta): {corrette}";

            int tentativiRimasti = maxTentativi - (rigaCorrente + 1);
            LblTentativi.Text = $"Tentativi rimanenti: {tentativiRimasti}";

            if (corrette == 4)
            {
                MessageBox.Show("✅ Complimenti! Hai indovinato il codice!");
                BtnVerifica.Enabled = false;
                return;
            }

            rigaCorrente++;

            if (rigaCorrente < righeNumeri.Count)
            {
                foreach (var n in righeNumeri[rigaCorrente])
                    n.Enabled = true;
            }
            else
            {
                MessageBox.Show($"❌ Hai esaurito i tentativi. Il codice era: {string.Join("", codiceSegreto)}");
                BtnVerifica.Enabled = false;
            }
        }

        private void SbloccaLucchetto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult risultato = MessageBox.Show($"Vuoi uscire da sblocca il lucchetto?",
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
                var nuovoForm = new SbloccaLucchetto();
                nuovoForm.StartPosition = FormStartPosition.Manual;
                nuovoForm.Location = posizione;
                nuovoForm.Show();
                this.Dispose();
            }
        }
    }
}
