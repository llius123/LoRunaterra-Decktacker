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

namespace LoRunaterra_Decktracker.API
{
    class ApiRunaterraJuego
    {
        public ActiveDeck getStaticDecklist()
        {
            ActiveDeck deckActivo = null;
            try
            {
                WebRequest request = WebRequest.Create(ConfigurationManager.AppSettings["api_runaterra"]);
                WebResponse response = request.GetResponse();
                
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    deckActivo = JsonConvert.DeserializeObject<ActiveDeck>(responseFromServer);

                    Console.WriteLine(deckActivo.DeckCode);
                }
                response.Close();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }

            return deckActivo;
        }
    }
}
