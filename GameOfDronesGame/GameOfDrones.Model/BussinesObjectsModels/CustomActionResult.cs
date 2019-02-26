using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace GameOfDrones.Model.BussinesObjectsModels
{
    public class CustomActionResult : IActionResult
    {
        /// <summary>
        /// Object to return on the response
        /// </summary>
        private object body;

        /// <summary>
        /// Status code to return on the response
        /// </summary>
        private int statusCode;

        /// <summary>
        /// Creates a new instance of the CustomActionResult class
        /// </summary>
        public CustomActionResult(int statusCode, object body)
        {
            this.body = body;
            this.statusCode = statusCode;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return null;
        }
    }
}
