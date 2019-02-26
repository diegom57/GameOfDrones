using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.TransactionsInterfaces
{
    public interface IGameTransactions
    {
        Task<bool> GameFinishAsync(string winnerName, string loserName);
    }
}
