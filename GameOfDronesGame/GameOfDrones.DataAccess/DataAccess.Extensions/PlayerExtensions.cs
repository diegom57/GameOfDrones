using GameOfDrones.DataAccess.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.DataAccess.DataAccess.Extensions
{
    /// <summary>
    /// Contains extension methods for <see cref="DbSet{TEntity}"/> where TEntity: <see cref="Player"/>
    /// </summary>
    public static class PlayerExtensions
    {
        public static IQueryable<Player> GetPlayerByName(this DbSet<Player> dbSet, string playerName, bool includeGamesList)
        {
            var context = dbSet.GetContext();
            var formatedName = playerName.Trim().ToUpper();
            

            if (includeGamesList)
            {
                return context.Player.Where(x => x.PlayerName.Trim().ToUpper() == formatedName).Include(x => x.Victories)
                .Include(x => x.Defeats);
            }
            else
            {
                return context.Player.Where(x => x.PlayerName.Trim().ToUpper() == formatedName);
            }
        }
    }
}
