using HelloWorld.Models;
using System;
using System.Linq;

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
                return; // DB has been seeded

            var games = new Game[] // sample data
            {
                new Game{ID = 1, Name = "test game 1", Box_art_url = "image url"},
                new Game{ID = 2, Name = "test game 2", Box_art_url = "image url"},
                new Game{ID = 3, Name = "test game 3", Box_art_url = "image url"}
            };

            foreach (var game in games)
                context.Games.Add(game);

            context.SaveChanges();
        }
    }
}
