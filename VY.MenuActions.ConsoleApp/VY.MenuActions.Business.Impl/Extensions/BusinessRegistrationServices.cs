using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VY.MenuActions.Business.Contracts.Services;
using VY.MenuActions.Business.Impl.Mapping_Profiles;
using VY.MenuActions.Business.Impl.Services;
using VY.MenuActions.Infraestructure.Impl.Extensions;
using VY.MenuActions.XCutting.Impl.Extensions;

namespace VY.MenuActions.Business.Impl.Extensions
{
    public static class BusinessRegistrationServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddInfrastructureServices(configuration);
            service.AddXCuttingServices(configuration);

            service.AddTransient<IExportService, ExportService>();
            service.AddTransient<IImportService, ImportService>();

            service.AddTransient<IAction, ExportService>();
            service.AddTransient<IAction, ImportService>()
                ;
            service.AddTransient<IActionFactory, ActionFactory>();

            service.AddTransient<IProcessor, MenuActionsProcessor>();

            service.AddTransient<IMenuActionService, MenuActionService>();

            service.AddAutoMapper(typeof(MenuActionProfile));
            return service;
        }
    }
}
