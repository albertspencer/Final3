using Microsoft.EntityFrameworkCore;

namespace Final3.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Declare as non-nullable
        public DbSet<Player> Players { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
    }
}
