using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.Model.BussinesObjectsModels
{
    public class PlayerBO
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public IEnumerable<GameBO> PlayerGames { get; set; }
        public int PlayerVictories
        {
            get
            {
                return PlayerGames.Count(x => x.WinnerId == PlayerId);
            }
        }
        public int PlayerTotalGames
        {
            get
            {
                return PlayerGames.Count();
            }
        }
        public int PlayerDefeats
        {
            get
            {
                return PlayerGames.Count(x => x.OpponentId == PlayerId);
            }
        }
        public int PlayerStreak
        {
            get
            {
                var lastDefeatDate = PlayerGames.Where(x => x.OpponentId == PlayerId)
                                    .OrderByDescending(x => x.GameDate).Select(x => x.GameDate)
                                    .FirstOrDefault();

                return PlayerGames.Count(x => x.WinnerId == PlayerId && x.GameDate > lastDefeatDate);
            }
        }
    }
}
