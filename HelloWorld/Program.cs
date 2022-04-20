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
        public static IList<Game> games = api.GetTopTenJSON();

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
        public class TwitchApiOutput
        {
            public Game[] Data { get; set; }
            public PaginationObject Pagination { get; set; }
        }

        public class PaginationObject
        {
            public string cursor { get; set; }
        }

        public IList<Game> GetTopTenJSON()
        {
            client.Headers.Add("Authorization: Bearer " + Auth);
            client.Headers.Add("Client-Id: " + Id);
            var apiJson = client.DownloadString("https://api.twitch.tv/helix/games/top");
            TwitchApiOutput twitchApiOutput = JsonConvert.DeserializeObject<TwitchApiOutput>(apiJson);
            return twitchApiOutput.Data.ToList();
        }
    }

    public class Game
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Box_art_url { get; set; }
    }
}