using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace VY.MenuActions.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, loggig) =>
                {
                    Log.Logger = new LoggerConfiguration()
                                     .WriteTo.Console()
                                     .WriteTo.MSSqlServer(
                                              connectionString: "Server=localhost\\SQLEXPRESS;Database=LogDB;Integrated Security=SSPI;",
                                              sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions()
                                              {
                                                  AutoCreateSqlTable = true,
                                                  TableName = "LogEvents"
                                              })
                                     .Enrich.FromLogContext()
                                     .CreateLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
