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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace HelloWorld.Pages
{
    public class IndexModel : PageModel
    {
        // below defines that objects we'll have access to in the view  
        // If this was an MVC architecture this would be the Model parts
        public Game[] GameList;

        // Model definitions end here

        private readonly ILogger<IndexModel> _logger; // nice we'll use this later
        private readonly Context _context;

        public IndexModel(ILogger<IndexModel> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }
        
        /// <summary>
        /// Called before the page loads, allowing you to set up the variables 
        /// that you want to use in the razor page when it draws
        /// </summary>

        public void OnGet()
        {

            //create array to hold top ten games
            GameList = _context.Games.ToArray();
        }
    }
}
