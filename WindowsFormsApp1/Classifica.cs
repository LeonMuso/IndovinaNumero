using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Classifica : Form
    {
        private string percorso = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Punteggi.json");
        public Classifica(string gioco = null)
        {
            InitializeComponent();
            MostraClassifica(gioco);
        }
        private void MostraClassifica(string gioco)
        {
            rtbClassifica.Clear();

            if (!File.Exists(percorso))
            {
                rtbClassifica.Text = "Nessun punteggio trovato.";
                return;
            }

            var json = File.ReadAllText(percorso);
            var punteggi = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(json)
                           ?? new Dictionary<string, Dictionary<string, int>>();

            if (gioco != null)
            {
                if (!punteggi.ContainsKey(gioco))
                {
                    rtbClassifica.Text = $"Nessun punteggio per {gioco}.";
                    return;
                }

                var classifica = punteggi[gioco]
                    .OrderByDescending(p => p.Value)
                    .Select((p, i) => $"{i + 1}. {p.Key} - {p.Value}");

                rtbClassifica.Text = $"{gioco}\n\n" + string.Join("\n", classifica);
            }
            else
            {
                foreach (var g in punteggi)
                {
                    rtbClassifica.AppendText($"{g.Key}:\n");
                    var classifica = g.Value
                        .OrderByDescending(p => p.Value)
                        .Select((p, i) => $"{i + 1}. {p.Key} - {p.Value}");
                    rtbClassifica.AppendText(string.Join("\n", classifica) + "\n\n");
                }
            }
        }
    }
}
