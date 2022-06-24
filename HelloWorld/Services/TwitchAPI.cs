using System.Net;
using System;
using System.Collections.Generic;
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
        public IList<Game> GetTopTenGames() 
        {
            using (var client = new WebClient())
            {
                IList<Game> topTenGames = new List<Game>();

                client.Headers.Add("Authorization: Bearer " + _auth);
                client.Headers.Add("Client-Id: " + _id);

                var jsonString = client.DownloadString("https://api.twitch.tv/helix/games/top");
                dynamic result = JsonConvert.DeserializeObject(jsonString);

                foreach (var game in result.data)
                {
                    topTenGames.Add(new Game { GameId = game.id, Name = game.name, Box_art_url = game.box_art_url});
                }

                return topTenGames;
            }
        }
    }
}


