using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using LoRDeckCodes;
using static LoRDeckCodes.LoRDeckEncoder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LoRDeckCodes;

namespace LoRunaterra_Decktracker.Global
{
     class jsonServices
    {


        public static void InsertarAJSON(ActiveDeck deck, GameResult game)
        {
            string path = "data.json";
            string deckCode = deck.DeckCode;
            bool result = game.LocalPlayerWon;

            if (File.Exists(path)) //Si ya existe el fichero donde guardar los datos
            {
                Console.WriteLine("Existe");
                string output = "";
                using (StreamReader reader = File.OpenText(path)) //Leemos el contenido del fichero
                {
                    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                    
                        JObject aux = (JObject)o.GetValue(deckCode); //Buscamos el mazo en el fichero con el que se ha jugado la partida
                        
                        if (aux != null)//Si ese mazo existe, es decir ya se ha jugado antes y se tienen datos sobre el, solamente se actualiza el valor de victorias o derrotas
                        {
                            //Obtenemos los parametros victoria y derrota
                            int victorias = (int)aux.GetValue("wins");
                            int derrotas = (int)aux.GetValue("lose");

                            if (result) //Actualizamos estos parámetros
                            { 
                                victorias++;
                            }
                            else
                            {
                                derrotas++;
                            }
                            
                            //Creamos un nuevo JObject con los datos actualizados
                            JObject nuevoRes = new JObject(
                                new JProperty("wins", victorias),
                                new JProperty("lose", derrotas));

                            o[deckCode] = nuevoRes; //Sustituimos los datos viejos por los nuevos
                            output = Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented); //Generamos el string para poder escribir a fichero
                    }
                    else //En caso de que no se tenga información sobre el mazo
                    {
                        JProperty newDeck = CreateJPropertyDeck(deckCode, result); //Se crea un Jproperty con la información del mazo

                        o.Add(newDeck);//Se le añade al JSON leido de fichero
                        output = Newtonsoft.Json.JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented); //Generamos el string para poder escribir a fichero
                    }
                    
                    reader.Close();
                }

                File.WriteAllText(path, output); //Escribimos en fichero

            }
            else //En caso de que no exista el fichero
            {
                
                Console.WriteLine("No Existe");

                JObject rss = CreateJObjectDeck(deckCode, result); //Creamos un objeto JSON que tiene el codigo del mazo y la información sobre victorias y derrotas

                //File.Create(path);
                using (StreamWriter file = File.CreateText(path)) //Se crea el fichero
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //Se escribe en el fichero
                    serializer.Serialize(file, rss); 
                }
            }
        }

        private static JObject CreateJObjectDeck(string deckCode, bool result) //Metodo usado para crear un JObject con la informacion del mazo, tiene la siguiente estructura {deckcode:{win:N, lose:M}}
        {
            JObject res;
            if (result)
            { 
                res = new JObject(
                    new JProperty(deckCode,
                        new JObject(
                            new JProperty("wins", 1),
                            new JProperty("lose", 0)
                        )));
            }
            else
            {
                res = new JObject(
                    new JProperty(deckCode,
                        new JObject(
                            new JProperty("wins", 0),
                            new JProperty("lose", 1)
                        )));
            }
            return res;
        }


        private static JProperty CreateJPropertyDeck(string deckCode, bool result) //Metodo usado para crear un JProperty con la informacion de un mazo nuevo a insertar en fichero existente deckcode:{win:N, lose:M}
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
            return newDeck;
        }

        public static List<string> GetFactions(String deckCode)
        {
            List<string> FactionList = new List<string>();
            List<CardCodeAndCount> aux = new List<CardCodeAndCount>();
            Console.WriteLine(deckCode);
            deckCode = deckCode.Substring(1, deckCode.Length-1);
            Console.WriteLine(deckCode);
            aux = GetDeckFromCode(deckCode);
            foreach (var x in aux)
            {
                
                string faction = GetCardFaction(x.CardCode);
                bool alreadyExists = FactionList.Contains(faction);
                if (!alreadyExists)
                {
                    FactionList.Add(faction);
                }
            }
            
            return FactionList;

        }

        private static string GetCardFaction(string cardCode)
        {
            string[] filePaths = Directory.GetFiles("cards-data");

            foreach (string path in filePaths)
            {
                using (StreamReader reader = File.OpenText(path)) //Leemos el contenido del fichero
                {
                    JArray o = (JArray) JToken.ReadFrom(new JsonTextReader(reader));
                    foreach (var card in o)
                    {
                        if ((string) card["cardCode"] == cardCode)
                        {
                            Console.WriteLine(card["region"]);
                            return (string) card["region"];
                        }
                        
                    }

                }
            }


            return "hola";
        }

    }
}