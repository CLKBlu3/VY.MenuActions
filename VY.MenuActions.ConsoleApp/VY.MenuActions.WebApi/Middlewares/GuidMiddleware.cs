using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace VY.MenuActions.WebApi.Middlewares
{
    public class GuidMiddleware
    {
        private readonly RequestDelegate _next;

        public GuidMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            LogContext.PushProperty("RequestId", Guid.NewGuid().ToString());
            await _next(context);
        }
    }
}
