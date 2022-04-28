using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
    /// <summary>
    /// represents a session with the database of games 
    /// </summary>
    
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { 
        }

        public DbSet<Game> Games { get; set; }
    }
}
 