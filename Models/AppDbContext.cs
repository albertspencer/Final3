using Microsoft.EntityFrameworkCore;

namespace Final3.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<GamePlayer> GamePlayers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure composite primary key for GamePlayer (Many-to-Many Relationship)
        modelBuilder.Entity<GamePlayer>()
            .HasKey(gp => new { gp.GameID, gp.PlayerID });

        // Define the relationship between GamePlayer and Game
        modelBuilder.Entity<GamePlayer>()
            .HasOne(gp => gp.Game)
            .WithMany(g => g.GamePlayers)
            .HasForeignKey(gp => gp.GameID);

        // Define the relationship between GamePlayer and Player
        modelBuilder.Entity<GamePlayer>()
            .HasOne(gp => gp.Player)
            .WithMany(p => p.GamePlayers)
            .HasForeignKey(gp => gp.PlayerID);
    }
}
