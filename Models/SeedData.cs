using Microsoft.EntityFrameworkCore;

namespace Final3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Database context cannot be null.");
            }

            if (context.Players == null || context.Games == null)
            {
                throw new InvalidOperationException("DbSet properties must not be null.");
            }

            if (context.Players.Any() || context.Games.Any())
            {
                return; // DB has been seeded
            }

            context.Players.AddRange(
                new Player { Name = "John Doe", Rank = 10 },
                new Player { Name = "Jane Smith", Rank = 20 },
                new Player { Name = "Sam Green", Rank = 15 }
            );

            context.Games.AddRange(
                new Game { Title = "The Great Adventure", ReleaseDate = DateTime.Parse("2023-10-15") },
                new Game { Title = "Racing Madness", ReleaseDate = DateTime.Parse("2024-01-10") }
            );

            context.SaveChanges();
        }
    }
}
