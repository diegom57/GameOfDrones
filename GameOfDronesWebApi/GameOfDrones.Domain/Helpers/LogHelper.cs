using GameOfDrones.DataAccess;
using GameOfDrones.DataAccess.DataAccess.Entities;
using GameOfDrones.Domain.TransactionsInterfaces;
using GameOfDrones.Model.BussinesObjectsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameOfDrones.Domain.Helpers.Enums;

namespace GameOfDrones.Domain.Helpers
{
    public class LogHelper : ILogHelper
    {
        // <summary>
        /// player Transactions 
        /// </summary>
        private readonly GodContext _context;

        /// <summary>
        /// Initializes a new Game transactions class instance
        /// </summary>
        public LogHelper(GodContext context)
        {
            _context = context;
        }

        public async Task LogActionAndDisposeContext(LogTypes logType, string message)
        {
            using (_context)
            {
                _context.Logging.Add(new Logging()
                {
                    LoggingDate = DateTime.Now,
                    LoggingMessage = message,
                    LoggingType = logType.ToString()
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task LogAction(LogTypes logType, string message)
        {
            _context.Logging.Add(new Logging()
            {
                LoggingDate = DateTime.Now,
                LoggingMessage = message,
                LoggingType = logType.ToString()
            });
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get Logs by date
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        public async Task<List<LoggingBO>> GetLogsByDate(DateTime dateFrom)
        {
            using (_context)
            {
                var logs = await _context.Logging.Where(x => x.LoggingDate >= dateFrom).ToListAsync();
                return ObjectMapper.Map(logs).ToList();
            }
        }

        /// <summary>
        /// Get las 20 logs
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        public async Task<List<LoggingBO>> GetLastTwentyLogs()
        {
            using (_context)
            {
                var logs = await _context.Logging.OrderByDescending(x => x.LoggingDate).Take(20).ToListAsync();
                return ObjectMapper.Map(logs).ToList();
            }
        }
    }
}
