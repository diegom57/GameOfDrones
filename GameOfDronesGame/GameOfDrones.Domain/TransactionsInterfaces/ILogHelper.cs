using GameOfDrones.DataAccess.DataAccess.Entities;
using GameOfDrones.Model.BussinesObjectsModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static GameOfDrones.Domain.Helpers.Enums;

namespace GameOfDrones.Domain.TransactionsInterfaces
{
    public interface ILogHelper
    {
        Task LogAction(LogTypes logType, string message);
        Task LogActionAndDisposeContext(LogTypes logType, string message);
        Task<List<LoggingBO>> GetLogsByDate(DateTime dateFrom);
        Task<List<LoggingBO>> GetLastTwentyLogs();
    }
}
