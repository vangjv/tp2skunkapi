using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class SkunkStatus
    {
        public Turn CurrentTurn { get; set; }
        public Turn LastTurn { get; set; }
        public List<Player> Players { get; set; }
        public bool GameVictory { get; set; }
        public bool TournamentVictory { get; set; }

        public SkunkStatus (Turn currentTurn, List<Player> players)
        {
            CurrentTurn = currentTurn;
            Players = players;
            GameVictory = false;
            TournamentVictory = false;
        }

        public SkunkStatus(Turn currentTurn, List<Player> players, bool gameVictory, bool tournamentVictory, Turn lastTurn)
        {
            CurrentTurn = currentTurn;
            Players = players;
            GameVictory = gameVictory;
            TournamentVictory = tournamentVictory;
            LastTurn = lastTurn;
        }
    }
}
