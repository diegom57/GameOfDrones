using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfDrones.DataAccess.DataAccess.Entities
{
    public partial class Logging
    {
        public int LoggingId { get; set; }
        public System.DateTime LoggingDate { get; set; }
        public string LoggingType { get; set; }
        public string LoggingMessage { get; set; }
    }
}
