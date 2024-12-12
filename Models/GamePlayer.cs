namespace Final3.Models;

public class GamePlayer
{
    
    public int GameID { get; set; }
    public Game Game { get; set; } = null!; 

    
    public int PlayerID { get; set; }
    public Player Player { get; set; } = null!; 
}
