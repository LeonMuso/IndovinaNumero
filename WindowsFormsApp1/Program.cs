﻿using Microsoft.Win32.SafeHandles;
using SudokuWinForms;
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
            Application.Run(new MenuLog());

        }
    }
    public static class UtenteC
    {
        public static string NomeU { get; set; }
        public static string NomeU2 { get; set; }
        public static string Password { get; set; }
    }
}
