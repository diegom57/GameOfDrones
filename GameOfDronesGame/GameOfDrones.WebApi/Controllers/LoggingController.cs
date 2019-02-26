using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GameOfDrones.Domain.TransactionsInterfaces;
using GameOfDrones.Model.BussinesObjectsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GameOfDrones.Domain.Helpers.Enums;

namespace GameOfDrones.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        /// <summary>
        /// player Transactions 
        /// </summary>
        private readonly ILogHelper _logHelper;

        /// <summary>
        /// Initializes a new Logging controller instance
        /// </summary>
        public LoggingController(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        /// <summary>
        /// new log message post
        /// </summary>
        [HttpPost]
        [Route("LogAction")]
        public async Task<IActionResult> LogInfoMessage([FromBody]MessageBO message)
        {
           await _logHelper.LogActionAndDisposeContext(LogTypes.ClientInfo, message.Message);
            return new CustomActionResult((int)HttpStatusCode.OK, null);
        }

        /// <summary>
        /// new log message post
        /// </summary>
        [HttpPost]
        [Route("LogError")]
        public async Task<IActionResult> LogErrorMessage(string message)
        {
            await _logHelper.LogActionAndDisposeContext(LogTypes.ClientError, message);
            return new CustomActionResult((int)HttpStatusCode.OK, null);
        }

        /// <summary>
        /// new log message post
        /// </summary>
        [HttpGet]
        [Route("GetLog")]
        public async Task<IActionResult> GetLogByDateFrom(DateTime dateFrom)
        {
            var result = await _logHelper.GetLogsByDate(dateFrom);
            return new CustomActionResult((int)HttpStatusCode.OK, result);
        }

        /// <summary>
        /// new log message post
        /// </summary>
        [HttpGet]
        [Route("GetLastLogs")]
        public async Task<IActionResult> GetLastLogs()
        {
            var result = await _logHelper.GetLastTwentyLogs();
            return new CustomActionResult((int)HttpStatusCode.OK, result);
        }
    }
}