using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VY.MenuActions.XCutting.Contracts.Services;
using VY.MenuActions.XCutting.Impl.Services;

namespace VY.MenuActions.XCutting.Impl.Extensions
{
    public static class XCuttingRegistrationServices
    {
        public static IServiceCollection AddXCuttingServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<ISerializer, JsonSerializeService>();
            service.AddTransient<ISerializer, XmlSerializeService>();
            service.AddTransient<ISerializerFactory, SerializerFactory>();
            return service;
        }
    }
}
