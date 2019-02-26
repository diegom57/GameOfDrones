using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.DataAccess.DataAccess.Extensions
{
    public static class ExtensionsBase
    {
        /// <summary>
        /// Get current context for extensions
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbSet"></param>
        /// <returns></returns>
        public static GodContext GetContext<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class
        {
            return ((IInfrastructure<IServiceProvider>)dbSet).GetService<ICurrentDbContext>().Context as GodContext;
        }
    }
}
