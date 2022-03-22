using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VY.MenuActions.Infraestructure.Contracts.Repositories;
using VY.MenuActions.Infraestructure.Contracts.Services;
using VY.MenuActions.Infraestructure.Impl.Context;
using VY.MenuActions.Infraestructure.Impl.Repositories;
using VY.MenuActions.Infraestructure.Impl.Services;

namespace VY.MenuActions.Infraestructure.Impl.Extensions
{
    public static class InfrastructureRegistrationService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<MenuDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("MenuDb"));
            });

            service.AddTransient<IDataManager, FileManager>();
            service.AddTransient<IMenuActionRepository, MenuActionRepository>();
            return service;
        }
    }
}
