using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.DataAccess.DataAccess.Entities
{
    public partial class Player
    {
        public Player()
        {
            this.Victories = new HashSet<Game>();
            this.Defeats = new HashSet<Game>();
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public ICollection<Game> Victories { get; set; }

        public ICollection<Game> Defeats { get; set; }
    }
}
