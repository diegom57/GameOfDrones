using System;
using System.Net;
using System.Threading.Tasks;
using GameOfDrones.Domain.Transactions;
using GameOfDrones.Domain.TransactionsInterfaces;
using GameOfDrones.Model.BussinesObjectsModels;
using Microsoft.AspNetCore.Mvc;

namespace GameOfDrones.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// player Transactions 
        /// </summary>
        private readonly IGameTransactions _gameTransactions;

        /// <summary>
        /// Initializes a new Game controller instance
        /// </summary>
        public GameController(IGameTransactions gameTransactions)
        {
            _gameTransactions = gameTransactions;
        }

        [HttpPost]
        [Route("GameFinish")]
        public async Task<IActionResult> GameFinish([FromBody]GameApiRequest gameRequest)
        {
            await _gameTransactions.GameFinishAsync(gameRequest.winner, gameRequest.opponent);
            return new CustomActionResult((int)HttpStatusCode.OK, true);
        }
    }
}
