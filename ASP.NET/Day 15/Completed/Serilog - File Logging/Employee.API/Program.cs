using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Employee.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configSettings = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(configSettings["Serilog:LogPath"])
               .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            //SetUpDB(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    
                    logging.AddSerilog();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetUpDB(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<EmployeeContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    /* var logger = services.GetRequiredService<ILogger<Program>>();
                     logger.LogError(ex, "An error occurred creating the DB.");*/
                }
            }
        }

    }


}
