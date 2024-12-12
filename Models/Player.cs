using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Final3.Models
{
    public class Player
    {
        public int PlayerID { get; set; } 

        [Display(Name = "Player Name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Hours Played")]
        [Range(0, int.MaxValue, ErrorMessage = "Hours played must be a non negative value.")]
        public int HoursPlayed { get; set; }

        [Display(Name = "Favorite Game")]
        [StringLength(100)]
        public string FavoriteGame { get; set; } = string.Empty;

        
        public ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
    }
}
