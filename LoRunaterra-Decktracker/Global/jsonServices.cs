using System;
using System.IO;
using LoRunaterra_Decktracker.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoRunaterra_Decktracker.Global
{
     class jsonServices
    {


        public static void InsertarAJSON(ActiveDeck deck, GameResult game)
        {
            string path = "data.json";
            string deckCode = deck.DeckCode;
            bool result = game.LocalPlayerWon;

            if (File.Exists(path))
            {
                Console.WriteLine("Existe");
                string output = "";
                using (StreamReader reader = File.OpenText(path))
                {
                    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                    
                        JObject aux = (JObject)o.GetValue(deckCode);
                        
                        if (aux != null)
                        {
                            int victorias = (int)aux.GetValue("wins");
                            int derrotas = (int)aux.GetValue("lose");

                            if (result)
                            { 
                                victorias++;
                            }
                            else
                            {
                                derrotas++;
                            }

                            JObject nuevoRes = new JObject(
                                new JProperty("wins", victorias),
                                new JProperty("lose", derrotas));
                            o[deckCode] = nuevoRes;
                            output = Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented);
                    }
                    else
                    {
                        JProperty newDeck;
                        if (result)
                        {

                             newDeck =
                                 new JProperty(deckCode,
                                        new JObject(
                                            new JProperty("wins", 1),
                                            new JProperty("lose", 0)
                                        ));
                        }
                        else
                        {
                             newDeck =
                                
                                    new JProperty(deckCode,
                                        new JObject(
                                            new JProperty("wins", 0),
                                            new JProperty("lose", 1)
                                        ));
                        }

                        o.Add(newDeck);
                        output = Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented);
                    }
                    
                    reader.Close();
                }

                File.WriteAllText(path, output);

            }
            else
            {
                //{deckcode:{win:N, lose:M}}
                Console.WriteLine("No Existe");

                JObject rss;
                if (result)
                {
                    rss =
                       new JObject(
                           new JProperty(deckCode,
                               new JObject(
                                   new JProperty("wins", 1),
                                   new JProperty("lose", 0)
                                   )));
                }
                else
                {
                    rss =
                       new JObject(
                           new JProperty(deckCode,
                               new JObject(
                                   new JProperty("wins", 0),
                                   new JProperty("lose", 1)
                               )));
                }
                //File.Create(path);
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, rss);
                }






            }

        }



    }
}