using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRunaterra_Decktracker.Global
{
    class ActiveDeck
    {
        private string _deckCode;
        private Dictionary<string, int> _cardsInDeck;
        [JsonProperty("DeckCode")]
        public string DeckCode { get => _deckCode; set => _deckCode = value; }

        [JsonProperty("CardsInDeck")]
        public Dictionary<string, int> CardsInDeck { get => _cardsInDeck; set => _cardsInDeck = value; }
    }
}
