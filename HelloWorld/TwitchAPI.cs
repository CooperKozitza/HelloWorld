using System.Net;
using Newtonsoft.Json;

namespace HelloWorld
{
    public class TwitchAPI
    {
        public TwitchAPI(string auth, string id) //Constructor
        {
            Auth = auth;
            Id = id;
        }

        protected static string Auth { get; set; }
        protected static string Id { get; set; }

        protected static WebClient client = new WebClient(); //Used For Fetching JSON From Twitch API

        public TopGamesOutput.Game[] GetTopTenGames() //Returns Array Of Top Games Streaming On Twitch From Twitch API In The Form Of A Array Of Game Objects
        {
            client.Headers.Add("Authorization: Bearer " + Auth);
            client.Headers.Add("Client-Id: " + Id);
            return JsonConvert.DeserializeObject<TopGamesOutput>(client.DownloadString("https://api.twitch.tv/helix/games/top")).Data;
        }

        public class TopGamesOutput //Object Format Of Top Games JSON 
        {
            public class Game
            {
                public string Id { get; set; }
                public string Name { get; set; }
                public string Box_art_url { get; set; }
            }
            public class PaginationObject
            {
                public string cursor { get; set; }
            }

            public Game[] Data { get; set; }
            public PaginationObject Pagination { get; set; }
        }

    }
}


