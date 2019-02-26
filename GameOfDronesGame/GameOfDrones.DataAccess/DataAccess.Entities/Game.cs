using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.DataAccess.DataAccess.Entities
{
    public partial class Game
    {
        public Game() { }
        public Game(int winnerId, int opponentId)
        {
            this.WinnerId = winnerId;
            this.OpponentId = opponentId;
            this.GameDate = DateTime.Now;
        }

        public int GameId { get; set; }
        public System.DateTime GameDate { get; set; }
        public int WinnerId { get; set; }
        public int OpponentId { get; set; }

        public virtual Player Winner { get; set; }
        public virtual Player Opponent { get; set; }
    }
}
