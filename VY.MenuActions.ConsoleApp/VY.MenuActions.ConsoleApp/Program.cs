using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using VY.MenuActions.Business.Contracts.Domain;
using VY.MenuActions.Business.Contracts.Services;
using VY.MenuActions.Business.Impl.Extensions;
using VY.MenuActions.Business.Impl.Services;
using VY.MenuActions.Infraestructure.Contracts.Repositories;
using VY.MenuActions.Infraestructure.Contracts.Services;
using VY.MenuActions.XCutting.Contracts;
using VY.MenuActions.XCutting.Contracts.Services;

namespace VY.MenuActions.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var context = new ArgContext { Path = "test3.json", Action = ActionType.Export, Serializer = SerializerType.Json };

            var host = CreateHostBuilder(args).Build();

            var processor = host.Services.GetRequiredService<IProcessor>();

            await processor.Process(context);
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Configuration\\settings.json"));
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddBusinessServices(context.Configuration);
                });
        }
    }
}
