using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Data;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Pages
{
    public class IndexModel : PageModel
    {
        // below defines that objects we'll have access to in the view  
        // If this was an MVC architecture this would be the Model parts
        public Game[] GameList;

        // Model definitions end here

        private readonly ILogger<IndexModel> _logger; // nice we'll use this later

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Called before the page loads, allowing you to set up the variables 
        /// that you want to use in the razor page when it draws
        /// </summary>
        public void OnGet()
        {

            //create new API using Auth Token and Client ID
            // probalby should move these into a config file but I think ultimatly 
            // we'll want to be pulling them in differnetly, via OATH or something else so maybe not worry about that
            // yet
            var  api = new TwitchAPI("or94frz4dm83ru11ql2x9jlik2x9hd", "bscma5xlv1ylbfxj8wafj1jmkt2ycs");

            //create array to hold top ten games
            GameList = api.GetTopTenGames();
        }
    }
}
