using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScoreCalculator.Infrastructure.ErrorHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Infrastructure.Filters
{
    public class ApiExceptionFilterAtrribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Error apiError = null;
            if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                context.Exception = null;
                apiError = new Error(ex.Message);

                context.HttpContext.Response.StatusCode = int.Parse(ex.StatusCode.ToString());
            }
            {
#if !DEBUG
                    var msg = "An unhandled error occurred.";                
                    string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new Error(msg);
                apiError.detail = stack;

                context.HttpContext.Response.StatusCode = 500;
            }

            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
