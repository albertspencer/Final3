using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Final3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<AppDbContext>();

            context.Database.EnsureCreated();

            if (context.Players!.Any() || context.Games!.Any() || context.GamePlayers!.Any())
            {
                return; // Database already seeded
            }

            // Seed Games
            var games = new List<Game>
            {
                new Game { Title = "Elder Scrolls V: Skyrim", Genre = "RPG", ReleaseDate = DateTime.Parse("2011-11-11")},
                new Game { Title = "The Witcher 3", Genre = "Action RPG", ReleaseDate = DateTime.Parse("2015-05-19")},
                new Game { Title = "Stardew Valley", Genre = "Simulation", ReleaseDate = DateTime.Parse("2016-02-26")},
                new Game { Title = "Fortnite", Genre = "Battle Royale", ReleaseDate = DateTime.Parse("2017-07-25") },
                new Game { Title = "Minecraft", Genre = "Sandbox", ReleaseDate = DateTime.Parse("2011-11-18") },
                new Game { Title = "Overwatch 2", Genre = "Shooter", ReleaseDate = DateTime.Parse("2022-10-04")},
                new Game { Title = "Cyberpunk 2077", Genre = "Open-World RPG", ReleaseDate = DateTime.Parse("2020-12-10")},
                new Game { Title = "Apex Legends", Genre = "Battle Royale", ReleaseDate = DateTime.Parse("2019-02-04")},
                new Game { Title = "World of Warcraft", Genre = "MMORPG", ReleaseDate = DateTime.Parse("2004-11-23")},
                new Game { Title = "League of Legends", Genre = "MOBA", ReleaseDate = DateTime.Parse("2009-10-27")},
                new Game { Title = "Diablo IV", Genre = "Hack and Slash RPG", ReleaseDate = DateTime.Parse("2023-06-06")},
                new Game { Title = "Hades", Genre = "Rogue-like", ReleaseDate = DateTime.Parse("2020-09-17")},
                new Game { Title = "Valorant", Genre = "Shooter", ReleaseDate = DateTime.Parse("2020-06-02")},
                new Game { Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseDate = DateTime.Parse("2020-03-20")},
                new Game { Title = "Pokemon Scarlet and Violet", Genre = "Adventure", ReleaseDate = DateTime.Parse("2022-11-18")}
            };
            context.Games!.AddRange(games);
            context.SaveChanges();

            // Seed Players
           var players = new List<Player>
{
    new Player { Name = "Alice Johnson", HoursPlayed = 890, FavoriteGame = "Minecraft" },
    new Player { Name = "Bob Smith", HoursPlayed = 725, FavoriteGame = "Fortnite" },
    new Player { Name = "Catherine Lee", HoursPlayed = 650, FavoriteGame = "Stardew Valley" },
    new Player { Name = "Daniel Brown", HoursPlayed = 770, FavoriteGame = "Elder Scrolls V: Skyrim" },
    new Player { Name = "Ella Davis", HoursPlayed = 920, FavoriteGame = "The Witcher 3" },
    new Player { Name = "Frank Wilson", HoursPlayed = 520, FavoriteGame = "League of Legends" },
    new Player { Name = "Grace Hall", HoursPlayed = 810, FavoriteGame = "Overwatch 2" },
    new Player { Name = "Harry Adams", HoursPlayed = 590, FavoriteGame = "Diablo IV" },
    new Player { Name = "Ivy Thompson", HoursPlayed = 490, FavoriteGame = "Valorant" },
    new Player { Name = "Jack White", HoursPlayed = 680, FavoriteGame = "World of Warcraft" },
    new Player { Name = "Karen Bell", HoursPlayed = 430, FavoriteGame = "Terraria" },
    new Player { Name = "Larry Moore", HoursPlayed = 610, FavoriteGame = "Hades" },
    new Player { Name = "Monica Taylor", HoursPlayed = 770, FavoriteGame = "Dark Souls III" },
    new Player { Name = "Nathaniel Scott", HoursPlayed = 860, FavoriteGame = "Apex Legends" },
    new Player { Name = "Olivia Martinez", HoursPlayed = 650, FavoriteGame = "Animal Crossing: New Horizons" },
    new Player { Name = "Paul Harris", HoursPlayed = 540, FavoriteGame = "Elden Ring" },
    new Player { Name = "Quincy Wright", HoursPlayed = 820, FavoriteGame = "Pokemon Scarlet and Violet" },
    new Player { Name = "Rachel Nelson", HoursPlayed = 760, FavoriteGame = "Cyberpunk 2077" },
    new Player { Name = "Steve Clark", HoursPlayed = 890, FavoriteGame = "FIFA 23" },
    new Player { Name = "Tina Baker", HoursPlayed = 920, FavoriteGame = "The Witcher 3" },
    new Player { Name = "Uma Carter", HoursPlayed = 730, FavoriteGame = "Stardew Valley" },
    new Player { Name = "Victor Young", HoursPlayed = 810, FavoriteGame = "Call of Duty: Warzone" },
    new Player { Name = "Wendy Evans", HoursPlayed = 700, FavoriteGame = "Minecraft" },
    new Player { Name = "Xavier Brooks", HoursPlayed = 850, FavoriteGame = "Fortnite" },
    new Player { Name = "Yvonne Rivera", HoursPlayed = 600, FavoriteGame = "League of Legends" }
};
context.Players.AddRange(players);
context.SaveChanges();
            // Seed GamePlayers (Relationships)
            var gamePlayers = new List<GamePlayer>();
            var random = new Random();

            foreach (var player in players)
            {
                var gamesPlayed = random.Next(3, 6); // Each player plays between 3 and 5 games
                var selectedGames = games.OrderBy(_ => random.Next()).Take(gamesPlayed).ToList();

                foreach (var game in selectedGames)
                {
                    gamePlayers.Add(new GamePlayer
                    {
                        PlayerID = player.PlayerID,
                        GameID = game.GameID
                    });
                }
            }
            context.GamePlayers!.AddRange(gamePlayers);
            context.SaveChanges();
        }
    }
}
