using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyRestful.Infrastructure;
using Serilog;

namespace MyRestful.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "My Rest Api";
            var host = CreateWebHostBuilder(args).Build();
            using (var scope= host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var salesContext = services.GetRequiredService<MyContext>();
                    MyContextSeed.SeedAsync(salesContext, loggerFactory).Wait();
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e,"An error occured seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseUrls("http://0.0.0.0:5000")
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
