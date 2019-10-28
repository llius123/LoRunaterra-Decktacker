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
        private Card[] _cardsInDeck;
        public string DeckCode { get => _deckCode; set => _deckCode = value; }
        internal Card[] CardsInDeck { get => _cardsInDeck; set => _cardsInDeck = value; }
    }

    class Card
    {
        private string _code;
        private int _number;

        public int Number { get => _number; set => _number = value; }
        public string Code { get => _code; set => _code = value; }
    }
}
