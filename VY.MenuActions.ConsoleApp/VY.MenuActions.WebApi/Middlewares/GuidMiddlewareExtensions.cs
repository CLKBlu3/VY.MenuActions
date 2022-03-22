using Microsoft.AspNetCore.Builder;

namespace VY.MenuActions.WebApi.Middlewares
{
    public static class GuidMiddlewareExtensions
    {
        public static IApplicationBuilder UseGuidMiddleware(this IApplicationBuilder builder) 
                => builder.UseMiddleware<GuidMiddleware>();
    }
}
