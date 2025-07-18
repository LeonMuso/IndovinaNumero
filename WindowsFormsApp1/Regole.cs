using Newtonsoft.Json.Linq;
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
    public partial class Regole : Form
    {
        private string percorso = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RegoleComplete.json");

        public Regole()
        {
            InitializeComponent();
            MostraRegole();
        }

        private void MostraRegole()
        {
            rtbRegole.Clear();

            if (!File.Exists(percorso))
            {
                rtbRegole.Text = "File regole.json non trovato.";
                return;
            }

            try
            {
                var json = File.ReadAllText(percorso);
                var giochi = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(json);

                foreach (var gioco in giochi)
                {
                    rtbRegole.AppendText($"{gioco.Key}\n");
                    rtbRegole.AppendText(new string('-', gioco.Key.Length) + "\n");

                    foreach (var proprietà in gioco.Value.Properties())
                    {
                        var nome = proprietà.Name;
                        var valore = proprietà.Value;

                        if (valore.Type == JTokenType.String)
                        {
                            rtbRegole.AppendText($"{nome}: {valore}\n");
                        }
                        else if (valore.Type == JTokenType.Object)
                        {
                            rtbRegole.AppendText($"\n  {nome}:\n");

                            foreach (var sub in ((JObject)valore).Properties())
                            {
                                rtbRegole.AppendText($"    {sub.Name}: {sub.Value}\n");
                            }
                        }
                    }

                    rtbRegole.AppendText("\n\n");
                }
            }
            catch (Exception ex)
            {
                rtbRegole.Text = "Errore nella lettura del file JSON: " + ex.Message;
            }
            rtbRegole.SelectionStart = 0;
            rtbRegole.ScrollToCaret();
        }
    }
}
