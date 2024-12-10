using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final3.Migrations
{
    /// <inheritdoc />
    public partial class ResetSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "Players",
                newName: "HoursPlayed");

            migrationBuilder.AddColumn<string>(
                name: "FavoriteGame",
                table: "Players",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Games",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Games",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => new { x.GameID, x.PlayerID });
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_PlayerID",
                table: "GamePlayers",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "FavoriteGame",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "HoursPlayed",
                table: "Players",
                newName: "Rank");
        }
    }
}
