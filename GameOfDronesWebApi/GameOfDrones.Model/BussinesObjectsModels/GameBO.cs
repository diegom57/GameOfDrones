using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Model.BussinesObjectsModels
{
    public class GameBO
    {
        public int GameId { get; set; }
        public DateTime GameDate { get; set; }
        public int WinnerId { get; set; }
        public int OpponentId { get; set; }
    }
}
