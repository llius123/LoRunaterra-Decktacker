using Newtonsoft.Json.Linq;
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
using LoRunaterra_Decktracker.Global;
using Newtonsoft.Json;



namespace LoRunaterra_Decktracker
{
    public partial class Mazos : Form
    {
        public Mazos()
        {
            InitializeComponent();
            loadDecks();
        }

        private void loadDecks()
        {
            string path = "data.json";
            if (File.Exists(path))
            {
                using (StreamReader reader = File.OpenText(path)) //Leemos el contenido del fichero
                {
                    JObject o = (JObject) JToken.ReadFrom(new JsonTextReader(reader));
                    foreach(KeyValuePair<string, JToken> item in o)
                    {
                        
                        string deckCode = item.Key.ToString();

                        int victorias = (int) item.Value["wins"];
                        int derrotas = (int) item.Value["lose"];
                        List<string> DeckFactions = jsonServices.GetFactions(deckCode);
                        
                        int total = victorias + derrotas;
                        string decks = "";
                        foreach (string fact in DeckFactions)
                        { 
                            decks += ", " + fact;
                            
                        }
                        ListViewItem aux = new ListViewItem(decks);
                        aux.SubItems.Add(deckCode);
                        aux.SubItems.Add(victorias.ToString() + "/" + total.ToString());

                        listView1.Items.Add(aux);
                        
                        
                    }
                    reader.Close();
                }
            }
            else
            {
                
            }
        }
    }
}
