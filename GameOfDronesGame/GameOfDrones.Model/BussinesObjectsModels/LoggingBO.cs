using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.Model.BussinesObjectsModels
{
    public class LoggingBO
    {
        public int LoggingId { get; set; }
        public System.DateTime LoggingDate { get; set; }
        public string LoggingType { get; set; }
        public string LoggingMessage { get; set; }
    }
}
