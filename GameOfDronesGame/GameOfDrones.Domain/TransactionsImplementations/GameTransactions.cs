using GameOfDrones.DataAccess;
using GameOfDrones.DataAccess.DataAccess.Entities;
using GameOfDrones.Domain.Helpers;
using GameOfDrones.Domain.TransactionsInterfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GameOfDrones.Domain.Helpers.Enums;

namespace GameOfDrones.Domain.Transactions
{
    /// <summary>
    /// Class used to perform player transactions
    /// </summary>
    public class GameTransactions : IGameTransactions
    {
        /// <summary>
        /// player Transactions 
        /// </summary>
        private readonly GodContext _context;

        /// <summary>
        /// player Transactions 
        /// </summary>
        private readonly IPlayerTransactions _playerTransactions;

        /// <summary>
        /// player Transactions 
        /// </summary>
        private readonly ILogHelper _logHelper;

        /// <summary>
        /// Initializes a new Game transactions class instance
        /// </summary>
        public GameTransactions(GodContext context, IPlayerTransactions playerTransactions, ILogHelper logHelper)
        {
            _context = context;
            _playerTransactions = playerTransactions;
            _logHelper = logHelper;
        }

        /// <summary>
        /// Log the player before starting the game, if it doesn't exists it is created
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public async Task<bool> GameFinishAsync(string winnerName, string loserName)
        {
            try
            {
                using (_context)
                {
                    var winner = await _playerTransactions.GetPlayerByName(winnerName, false);
                    var loser = await _playerTransactions.GetPlayerByName(loserName, false);

                    var newGame = new Game(winner.PlayerId, loser.PlayerId);

                    _context.Game.Add(newGame);

                    await _context.SaveChangesAsync();

                    await _logHelper.LogAction(LogTypes.Info, string.Format("{0} has won against {1}", winnerName, loserName));
                }
            }
            catch (Exception ex)
            {
                await _logHelper.LogActionAndDisposeContext(LogTypes.Info, string.Format("{0} has thrown the error below: message : {1}", MethodBase.GetCurrentMethod().ToString(), ex.Message));
                return false;
            }
            return true;
        }
    }
}
