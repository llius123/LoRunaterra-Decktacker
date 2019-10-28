using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRunaterra_Decktracker.Global
{
    class GameResult
    {
        private int _GameID;
        private Boolean _LocalPlayerWon;

        public int GameID { get => _GameID; set => _GameID = value; }
        public bool LocalPlayerWon { get => _LocalPlayerWon; set => _LocalPlayerWon = value; }
    }
}
