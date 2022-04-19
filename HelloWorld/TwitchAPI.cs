using System.Net;

namespace TwitchAPI
{
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

	public string GetTopTenJSON()
		{
			client.Headers.Add("Authorization: Bearer " + Auth);
			client.Headers.Add("Client-Id: " + Id);
			return client.DownloadString("https://api.twitch.tv/helix/games/top");
		}
	}
}
