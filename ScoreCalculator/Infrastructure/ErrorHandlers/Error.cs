using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Infrastructure.ErrorHandlers
{
    public class Error
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }

        public Error(string message)
        {
            this.message = message;
            isError = true;
        }
    }
}
