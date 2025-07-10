using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogIn logIn = new LogIn();
            if (logIn.ShowDialog() == DialogResult.OK)
            {
                
                Application.Run(new MenuLog());
            }

        }
    }
    public static class UtenteC
    {
        public static string NomeU { get; set; }
        public static string NomeU2 { get; set; }
    }
}
