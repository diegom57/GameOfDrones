using GameOfDrones.DataAccess;
using GameOfDrones.DataAccess.DataAccess.Entities;
using GameOfDrones.DataAccess.DataAccess.Extensions;
using GameOfDrones.Domain.Helpers;
using GameOfDrones.Domain.TransactionsInterfaces;
using GameOfDrones.Model.BussinesObjectsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GameOfDrones.Domain.Helpers.Enums;

namespace GameOfDrones.Domain.Transactions
{
    /// <summary>
    /// Class used to perform player transactions
    /// </summary>
    public class PlayerTransactions : IPlayerTransactions
    {
        /// <summary>
        /// God Context
        /// </summary>
        private readonly GodContext _context;

        /// <summary>
        /// Log helper
        /// </summary>
        private readonly ILogHelper _logHelper;

        /// <summary>
        /// Initializesa new PlayerTransaction class instance
        /// </summary>
        /// <param name="context">Bioforest context</param>
        public PlayerTransactions(GodContext context, ILogHelper logHelper)
        {
            _context = context;
            _logHelper = logHelper;
        }

        /// <summary>
        /// Get the player by name
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="includeGamesList"></param>
        /// <returns></returns>
        public async Task<Player> GetPlayerByName(string playerName, bool includeGamesList)
        {
            return await _context.Player.GetPlayerByName(playerName, includeGamesList).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Log the player before starting the game, if it doesn't exists it is created
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public async Task<PlayerBO> PlayerLogInAsync(string playerName)
        {
            try
            {
                using (_context)
                {
                    var currentPlayer = await GetPlayerByName(playerName, true);

                    if (currentPlayer == null)
                    {
                        currentPlayer = new Player() { PlayerName = playerName };
                        _context.Player.Add(currentPlayer);
                    }
                    await _logHelper.LogAction(LogTypes.Info, string.Format("Player {0} has been logged in", playerName));
                    return ObjectMapper.Map(currentPlayer);
                }       
            }
            catch (Exception ex)
            {
                await _logHelper.LogActionAndDisposeContext(LogTypes.Info, string.Format("{0} has thrown the error below: message : {1}", MethodBase.GetCurrentMethod().ToString(), ex.Message));
                return null;
            }
        }
    }
}
