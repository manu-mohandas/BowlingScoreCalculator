using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ScoreCalculator.Infrastructure.ErrorHandlers
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(string message, HttpStatusCode statuscode = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = statuscode;
        }

        public ApiException(Exception ex, HttpStatusCode statuscode = HttpStatusCode.InternalServerError) : base(ex.Message)
        {
            StatusCode = statuscode;
        }
    }
}
