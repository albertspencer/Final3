using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Final3.Models;

public class Game
{
    public int GameID { get; set; } 

    [Display(Name = "Game Title")]
    [Required]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Genre")]
    [StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Developer")]
    [StringLength(100)]
    public string Developer { get; set; } = string.Empty;

    
    public ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
}
