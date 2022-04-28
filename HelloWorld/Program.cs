using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using HelloWorld.Models;
using HelloWorld.Data;
using HelloWorld.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            CreateDatabase(host);

            host.Run();
        }

        

        private static void CreateDatabase(IHost host)
        {
            TwitchAPI api = new TwitchAPI("or94frz4dm83ru11ql2x9jlik2x9hd", "bscma5xlv1ylbfxj8wafj1jmkt2ycs");
            Game[] games = api.GetTopTenGames();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SiteContext>();
                    DbInitializer.Initialize(context, games);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}