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
                new Game { Title = "Elder Scrolls V: Skyrim", Genre = "RPG", ReleaseDate = DateTime.Parse("2011-11-11"), Developer = "Bethesda Game Studios" },
                new Game { Title = "The Witcher 3", Genre = "Action RPG", ReleaseDate = DateTime.Parse("2015-05-19"), Developer = "CD Projekt Red" },
                new Game { Title = "Cyberpunk 2077", Genre = "Open-World RPG", ReleaseDate = DateTime.Parse("2020-12-10"), Developer = "CD Projekt Red" },
                new Game { Title = "Stardew Valley", Genre = "Simulation", ReleaseDate = DateTime.Parse("2016-02-26"), Developer = "ConcernedApe" },
                new Game { Title = "Call of Duty: Warzone", Genre = "Shooter", ReleaseDate = DateTime.Parse("2020-03-10"), Developer = "Infinity Ward" },
                new Game { Title = "Fortnite", Genre = "Battle Royale", ReleaseDate = DateTime.Parse("2017-07-25"), Developer = "Epic Games" },
                new Game { Title = "Minecraft", Genre = "Sandbox", ReleaseDate = DateTime.Parse("2011-11-18"), Developer = "Mojang" },
                new Game { Title = "League of Legends", Genre = "MOBA", ReleaseDate = DateTime.Parse("2009-10-27"), Developer = "Riot Games" },
                new Game { Title = "World of Warcraft", Genre = "MMORPG", ReleaseDate = DateTime.Parse("2004-11-23"), Developer = "Blizzard Entertainment" },
                new Game { Title = "Apex Legends", Genre = "Battle Royale", ReleaseDate = DateTime.Parse("2019-02-04"), Developer = "Respawn Entertainment" },
                new Game { Title = "Valorant", Genre = "Shooter", ReleaseDate = DateTime.Parse("2020-06-02"), Developer = "Riot Games" },
                new Game { Title = "Overwatch 2", Genre = "Shooter", ReleaseDate = DateTime.Parse("2022-10-04"), Developer = "Blizzard Entertainment" },
                new Game { Title = "Diablo IV", Genre = "Hack and Slash RPG", ReleaseDate = DateTime.Parse("2023-06-06"), Developer = "Blizzard Entertainment" },
                new Game { Title = "Hades", Genre = "Rogue-like", ReleaseDate = DateTime.Parse("2020-09-17"), Developer = "Supergiant Games" },
                new Game { Title = "Terraria", Genre = "Sandbox Adventure", ReleaseDate = DateTime.Parse("2011-05-16"), Developer = "Re-Logic" },
                new Game { Title = "Dark Souls III", Genre = "Action RPG", ReleaseDate = DateTime.Parse("2016-03-24"), Developer = "FromSoftware" },
                new Game { Title = "Elden Ring", Genre = "RPG", ReleaseDate = DateTime.Parse("2022-02-25"), Developer = "FromSoftware" },
                new Game { Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseDate = DateTime.Parse("2020-03-20"), Developer = "Nintendo" },
                new Game { Title = "Pokémon Scarlet and Violet", Genre = "Adventure", ReleaseDate = DateTime.Parse("2022-11-18"), Developer = "Game Freak" },
                new Game { Title = "FIFA 23", Genre = "Sports", ReleaseDate = DateTime.Parse("2022-09-27"), Developer = "EA Sports" }
            };
            context.Games!.AddRange(games);
            context.SaveChanges();

            // Seed Players
            var players = new List<Player>();
            for (int i = 1; i <= 50; i++)
            {
                players.Add(new Player
                {
                    Name = $"Player {i}",
                    HoursPlayed = new Random().Next(10, 1000),
                    CurrentLevel = new Random().Next(1, 100)
                });
            }
            context.Players!.AddRange(players);
            context.SaveChanges();

            // Seed GamePlayers (Relationships)
            var gamePlayers = new List<GamePlayer>();
            var random = new Random();

            for (int i = 1; i <= players.Count; i++)
            {
                var gamesPlayed = random.Next(2, 6); // Each player plays between 2 and 5 games
                var selectedGames = games.OrderBy(_ => random.Next()).Take(gamesPlayed).ToList();

                foreach (var game in selectedGames)
                {
                    gamePlayers.Add(new GamePlayer
                    {
                        PlayerID = i,
                        GameID = game.GameID
                    });
                }
            }
            context.GamePlayers!.AddRange(gamePlayers);
            context.SaveChanges();
        }
    }
}
