using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //create new API using Auth Token and Client ID
        public static TwitchAPI api = new TwitchAPI("or94frz4dm83ru11ql2x9jlik2x9hd", "bscma5xlv1ylbfxj8wafj1jmkt2ycs");
        //create array to hold top ten games
        public static TwitchAPI.TopGamesOutput.Game[] games = api.GetTopTenGames();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}