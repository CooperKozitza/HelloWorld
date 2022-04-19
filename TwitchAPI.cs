using System;
using System.Net;

public class TwitchAPI
{
	public string Auth { get; set; }
	public string Id { get; set; }
	public TwitchAPI(string auth, string id) : Auth(auth), Id(id) { };

	WebClient client = new WebClient()
	client.Headers.Add("Authorization: Bearer " + Auth);
	client.Headers.Add("Client-Id: " + Id);

	public string GetTopTen()
	{
		return client.DownloadString("https://api.twitch.tv/helix/games/top");
	}
}
