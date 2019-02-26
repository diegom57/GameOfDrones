using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfDrones.DataAccess;
using GameOfDrones.Domain.TransactionsInterfaces;
using GameOfDrones.Model.BussinesObjectsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameOfDrones.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        /// <summary>
        /// player Transactions 
        /// </summary>
        private readonly IPlayerTransactions _playerTransactions;

        /// <summary>
        /// Initializes a new instance of the Player Controller class
        /// </summary>
        public PlayerController(IPlayerTransactions playerTransactions) 
        {
            _playerTransactions = playerTransactions;
        }

        // GET: api/Game
        [HttpGet]
        [Route("PlayerLogIn")]
        public async Task<PlayerBO> PlayerLogIn(string playerName)
        {
            return await _playerTransactions.PlayerLogInAsync(playerName);
        }
    }
}