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
    public partial class Form2 : Form
    {
        Random random = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void BtnVerifica_Click(object sender, EventArgs e)
        {
            int[] codGiocatore = new int[]
            {
                (int)Num1.Value
                , (int)Num2.Value
                , (int)Num3.Value
                , (int)Num4.Value
            };
            int numCorretti = 0;

            foreach ()
                LblCorrette.Text = $"Numeri in posizione corretta: {numCorretti}";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int[] codice = Enumerable.Range(0, 10).OrderBy(x => random.Next()).Take(4).ToArray();
        }
    }
}
