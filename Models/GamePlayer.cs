namespace Final3.Models;

public class GamePlayer
{
    // Foreign Key for Game
    public int GameID { get; set; }
    public Game Game { get; set; } = null!; // Navigation Property

    // Foreign Key for Player
    public int PlayerID { get; set; }
    public Player Player { get; set; } = null!; // Navigation Property
}
