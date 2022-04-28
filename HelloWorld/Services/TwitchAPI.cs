using System.Net;
using HelloWorld.Models;
using Newtonsoft.Json;

namespace HelloWorld.Services
{
    public class TwitchAPI
    {
        private string _auth { get; set; }
        private string _id { get; set; }

        /// <summary>
        /// Service used for calling Twitch API
        /// </summary>
        /// <param name="auth">the Auth token you generated</param>
        /// <param name="id">the application ID</param>
        public TwitchAPI(string auth, string id) 
        {
            _auth = auth;
            _id = id;
        }

        /// <summary>
        /// Returns Array Of Top Games Streaming On Twitch From Twitch API In The Form Of A Array Of Game Objects
        /// </summary>
        /// <returns></returns>
        public Game[] GetTopTenGames() 
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization: Bearer " + _auth);
                client.Headers.Add("Client-Id: " + _id);

                var jsonString = client.DownloadString("https://api.twitch.tv/helix/games/top");
                TopGamesResponse result = JsonConvert.DeserializeObject<TopGamesResponse>(jsonString);

                return result.Data;
            }
        }

        /// <summary>
        /// Response Object Format Of Top Games JSON 
        /// </summary>
        private class TopGamesResponse 
        {
            protected class PaginationObject
            {
                public string cursor { get; set; }
            }

            public Game[] Data { get; set; }
            protected PaginationObject Pagination { get; set; }
        }
    }
}


