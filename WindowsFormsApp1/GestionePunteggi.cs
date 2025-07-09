using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace WindowsFormsApp1
{
    public static class GestionePunteggi
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "punteggi.json"); 

        private static Dictionary<string, Dictionary<string, int>> dati = new Dictionary<string, Dictionary<string, int>>();

        static GestionePunteggi()
        {
            Carica();
        }

        private static void Carica()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                dati = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(json);
                if (dati == null)
                {
                    dati = new Dictionary<string, Dictionary<string, int>>();
                }
            }
            else
            {
                dati = new Dictionary<string, Dictionary<string, int>>();

                dati["IndovinaNumero"] = new Dictionary<string, int>();
                dati["Lucchetto"] = new Dictionary<string, int>();
                dati["CampoMinato"] = new Dictionary<string, int>();
                dati["Poker"] = new Dictionary<string, int>();
                dati["BOMB"] = new Dictionary<string, int>();


                Salva();
            }
        }

        public static void AggiornaPunteggio(string gioco, string utente, int nuovoPunteggio)
        {
            if (!dati.ContainsKey(gioco))
                dati[gioco] = new Dictionary<string, int>();

            dati[gioco][utente] = nuovoPunteggio;
            Salva();
        }

        public static int OttieniPunteggio(string gioco, string utente)
        {
            if (dati.ContainsKey(gioco) && dati[gioco].ContainsKey(utente))
            {
                    return dati[gioco][utente];
            }
            return 0;
        }

        private static void Salva()
        {
            string json = JsonConvert.SerializeObject(dati, Formatting.Indented);
            File.WriteAllText(filePath, json);
            MessageBox.Show("punteggio salvato");
        }
    }
}
