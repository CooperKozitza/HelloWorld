using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            CreateHostBuilder(args, config).Build().Run();
        }

    
    
      


        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                //    webBuilder.ConfigureServices()
                })
                .ConfigureServices(services =>
                    {
                        
                        // inject services here
                        services.AddSingleton(config);
                    });
 

    }
}