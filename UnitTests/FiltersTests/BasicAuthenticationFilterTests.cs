using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using ScoreCalculator.Infrastructure.ErrorHandlers;
using ScoreCalculator.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.FiltersTests
{
    [TestFixture]
    public class BasicAuthenticationFilterTests
    {
        [Test]
        public void Empty_authorization_header_return_BadRequest()
        {
            var httpContext = new DefaultHttpContext();
            var context = new AuthorizationFilterContext(new ActionContext
            {
                HttpContext = httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()

            }, new List<IFilterMetadata>()); ;

            var result = new BasicAuthenticationFilter();
            Assert.Throws<ApiException>(() => result.OnAuthorization(context));
        }

        [Test]
        public void Request_with_authorization_header_return_OkRequest()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers.Add("Authorization", "Basic c2NvcmVjYWxjdWxhdG9yOnNjb3JlY2FsY3VsYXRvcg==");
            var context = new AuthorizationFilterContext(new ActionContext
            {
                HttpContext = httpContext,
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()

            }, new List<IFilterMetadata>()); ;

            var result = new BasicAuthenticationFilter();
            result.OnAuthorization(context);

            Assert.AreEqual(200, context.HttpContext.Response.StatusCode);
        }
    }
}
