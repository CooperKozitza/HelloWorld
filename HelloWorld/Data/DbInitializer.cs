using HelloWorld.Models;

namespace HelloWorld.Data
{
    public class DbInitializer
    {
        public static void Initialize(SiteContext context, Game[] games)
        {
            context.Database.EnsureCreated();

            foreach (Game game in games)
                context.Games.Add(game);
            context.SaveChanges();
        }
    }
}
