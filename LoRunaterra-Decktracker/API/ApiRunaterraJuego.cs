using LoRunaterra_Decktracker.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoRunaterra_Decktracker.API
{
    class ApiRunaterraJuego
    {
        
       
        public async void IniciarBusqueda(Label label_status)
        {
            ActiveDeck deckActivo = null;
            //Pregunto todo el rato si el jugador a entrado en partida
            do
            {
                deckActivo = getStaticDecklist();
                await Task.Delay(1000);
                label_status.Text = "Buscando partida";
                Console.WriteLine("Buscando partida");
                
            } while (deckActivo.DeckCode == null);
            Console.WriteLine("Partida encontrada");
            label_status.Text = "Partida encontrada";
            //Se que esta en partida y pregunto todo el rato a ver si a acabado
            GameResult resultado = null;
            ActiveDeck deckEnPartida = null;
            //Pregunto todo el rato si el jugador a acabado la partida
            do
            {
                deckEnPartida = getStaticDecklist();
                await Task.Delay(1000);
                Console.WriteLine("En partida");
                label_status.Text = "En partida";
            } while (deckEnPartida.DeckCode != null);
            resultado = getGameResult();
            Console.WriteLine("Partida Acabada");
            label_status.Text = "Partida acabada";
            IniciarBusqueda(label_status);

        }
        public ActiveDeck getStaticDecklist()
        {
            ActiveDeck deckActivo = null;
            try
            {
                WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings["api_runaterra"] + "/static-decklist");
                WebResponse response = request.GetResponse();
                
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    deckActivo = JsonConvert.DeserializeObject<ActiveDeck>(responseFromServer);
                }
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return deckActivo;
        }

        public GameResult getGameResult()
        {
            GameResult resultado = null;
            try
            {
                WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings["api_runaterra"] + "/game-result");
                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    resultado = JsonConvert.DeserializeObject<GameResult>(responseFromServer);
                }
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return resultado;
        }
    }
}
