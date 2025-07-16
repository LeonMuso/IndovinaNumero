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
    public partial class Puntata : Form
    {
        public int ImportoPuntata { get; private set; } = 0;
        public bool AllIn { get; private set; } = false;

        public Puntata(int massimoDisponibile)
        {
            InitializeComponent();

            Label lbl = new Label { Text = $"Punta (max {massimoDisponibile}):", Top = 20, Left = 10, AutoSize = true };
            TextBox txtImporto = new TextBox { Top = 50, Left = 10, Width = 150, Name = "txtImporto" };
            CheckBox chkAllIn = new CheckBox { Top = 80, Left = 10, Text = "All-in", Name = "chkAllIn", AutoSize = true };
            Button btnOk = new Button { Text = "OK", Top = 110, Left = 10, DialogResult = DialogResult.OK };
            this.AcceptButton = btnOk;

            btnOk.Click += (s, e) =>
            {
                if (chkAllIn.Checked)
                {
                    AllIn = true;
                    ImportoPuntata = massimoDisponibile;
                }
                else
                {
                    if (!int.TryParse(txtImporto.Text, out int valore) || valore <= 0 || valore > massimoDisponibile)
                    {
                        MessageBox.Show("Importo non valido");
                        this.DialogResult = DialogResult.None;
                        return;
                    }
                    ImportoPuntata = valore;
                }
            };

            Controls.Add(lbl);
            Controls.Add(txtImporto);
            Controls.Add(chkAllIn);
            Controls.Add(btnOk);

            Text = "Inserisci Puntata";
            Width = 200;
            Height = 200;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
        }
    }
}
