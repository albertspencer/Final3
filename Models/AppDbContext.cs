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
      
        modelBuilder.Entity<GamePlayer>().HasKey(gp => new { gp.GameID, gp.PlayerID });

       
        modelBuilder.Entity<GamePlayer>().HasOne(gp => gp.Game).WithMany(g => g.GamePlayers).HasForeignKey(gp => gp.GameID);

       
        modelBuilder.Entity<GamePlayer>().HasOne(gp => gp.Player).WithMany(p => p.GamePlayers).HasForeignKey(gp => gp.PlayerID);
    }
}
