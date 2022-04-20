using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static TwitchAPI api = new TwitchAPI("or94frz4dm83ru11ql2x9jlik2x9hd", "bscma5xlv1ylbfxj8wafj1jmkt2ycs");
        public static List<Game> games = JsonConvert.DeserializeObject<List<Game>>(api.GetTopTenJSON());

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class TwitchAPI
    {
        public TwitchAPI(string auth, string id)
        {
            Auth = auth;
            Id = id;
        }


        protected string Auth { get; set; }
        protected string Id { get; set; }

        protected WebClient client = new WebClient();
        public class TwitchApiReturn
        {
            public string data { get; set; }
            public string pagination { get; set; }
        }

        public string GetTopTenJSON()
        {
            client.Headers.Add("Authorization: Bearer " + Auth);
            client.Headers.Add("Client-Id: " + Id);
            var api = client.DownloadString("https://api.twitch.tv/helix/games/top");
            TwitchApiReturn twitchApiReturn = JsonConvert.DeserializeObject<TwitchApiReturn>(api);
            return twitchApiReturn.data;
        }
    }

    public class Game
    {
        public string id { get; set; }
        public string name { get; set; }
        public string box_art_url { get; set; }
    }
}