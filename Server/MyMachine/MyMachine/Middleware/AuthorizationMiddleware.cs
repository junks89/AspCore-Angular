using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shared;

namespace MyMachine.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthorizationModel _model;

        public AuthorizationMiddleware(RequestDelegate next,
            AuthorizationModel model)
        {
            _next = next;
            _model = model;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader.Count == 0)
            {
                _model.IsAuthorized = false;
                _model.Role = "";
                return _next(httpContext);
            }
            var tt = new TokenTools();
            _model.IsAuthorized = tt.ValidateToken(authHeader, _model);
            return _next(httpContext);
        }
    }

    public static class AuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
