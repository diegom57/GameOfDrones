using GameOfDrones.DataAccess.DataAccess.Entities;
using GameOfDrones.Model.BussinesObjectsModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.TransactionsInterfaces
{
    public interface IPlayerTransactions
    {
        /// <summary>
        /// Log the player before starting the game, if it doesn't exists it is created
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        Task<PlayerBO> PlayerLogInAsync(string playerName);

        /// <summary>
        /// Get the player by name
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        Task<Player> GetPlayerByName(string playerName, bool includeGamesList);
    }
}
