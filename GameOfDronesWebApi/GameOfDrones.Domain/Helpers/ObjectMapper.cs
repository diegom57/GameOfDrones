using GameOfDrones.DataAccess.DataAccess.Entities;
using GameOfDrones.Model.BussinesObjectsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.Domain.Helpers
{
    /// <summary>
    /// class used to perform mapping between business objects 
    /// and data base objects
    /// </summary>
    public static class ObjectMapper
    {
        public static GameBO Map(Game gameEntity)
        {
            return new GameBO()
            {
                GameDate = gameEntity.GameDate,
                GameId = gameEntity.GameId,
                OpponentId = gameEntity.OpponentId,
                WinnerId = gameEntity.WinnerId
            };
        }

        public static PlayerBO Map(Player playerEntity)
        {
            return new PlayerBO()
            {
                PlayerId = playerEntity.PlayerId,
                PlayerName = playerEntity.PlayerName,
                PlayerGames = Map(playerEntity.Victories.Union(playerEntity.Defeats))
            };
        }

        public static Game Map(GameBO gameBO)
        {
            return new Game()
            {
                GameDate = gameBO.GameDate,
                GameId = gameBO.GameId,
                OpponentId = gameBO.OpponentId,
                WinnerId = gameBO.WinnerId
            };
        }

        public static IEnumerable<GameBO> Map(IEnumerable<Game> gameEntities)
        {
            return (from gameEntity in gameEntities
                    select new GameBO()
                    {
                        GameDate = gameEntity.GameDate,
                        GameId = gameEntity.GameId,
                        OpponentId = gameEntity.OpponentId,
                        WinnerId = gameEntity.WinnerId
                    }).ToList();
        }

        public static IEnumerable<LoggingBO> Map(IEnumerable<Logging> logEntities)
        {
            return (from logEntity in logEntities
                    select new LoggingBO()
                    {
                        LoggingId = logEntity.LoggingId,
                        LoggingDate = logEntity.LoggingDate,
                        LoggingMessage = logEntity.LoggingMessage,
                        LoggingType = logEntity.LoggingType
                    }).ToList();
        }

        public static List<PlayerBO> Map(List<Player> playerEntities)
        {
            return (from playerEntity in playerEntities
                    select new PlayerBO()
                    {
                        PlayerId = playerEntity.PlayerId,
                        PlayerName = playerEntity.PlayerName
                    }).ToList();
        }
    }
}
