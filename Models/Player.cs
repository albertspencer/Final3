using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Final3.Models
{
    public class Player
    {
        public int PlayerID { get; set; } // Primary Key

        [Display(Name = "Player Name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Hours Played")]
        [Range(0, int.MaxValue, ErrorMessage = "Hours played must be a non-negative value.")]
        public int HoursPlayed { get; set; }

        [Display(Name = "Favorite Game")]
        [StringLength(100)]
        public string FavoriteGame { get; set; } = string.Empty;

        // Navigation property for the many-to-many relationship with Game
        public ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
    }
}
