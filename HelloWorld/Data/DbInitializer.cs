using HelloWorld.Models;
using HelloWorld.Services;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWorld.Data
{
    /// <summary>
    /// Initializes database using context. If no database exists, db is initialized with sample data
    /// </summary>

    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any()) // look for existing data
            {
                return; // DB has been seeded
            }

            var api = new TwitchAPI("rxxoreg3dh7ts96qp8yy77ygk4wi1k", "bscma5xlv1ylbfxj8wafj1jmkt2ycs");

            IList<Game> games = api.GetTopTenGames();

            foreach (var game in games)
            {
                context.Games.Add(game);
            }

            context.SaveChanges();
        }
    }
}
