using Microsoft.AspNetCore.Mvc.Filters;
using ScoreCalculator.Infrastructure.ErrorHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Infrastructure.Filters
{
    public class BasicAuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader))
            {
                var authHeadValue = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeadValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    var credentials = Encoding.UTF8
                                        .GetString(Convert.FromBase64String(authHeadValue.Parameter ?? string.Empty))
                                        .Split(new char[] { ':' }, 2);
                    if (credentials.Length == 2)
                    {
                        if (IsValid(credentials[0], credentials[1]))
                        {
                            return;
                        }
                    }
                }
            }

            throw new ApiException("Unauthorized", HttpStatusCode.Forbidden);
        }

        private bool IsValid(string userName, string password)
        {
            if (userName == "scorecalculator" && password == "scorecalculator")
            {
                return true;
            }

            return false;
        }
    }
}
