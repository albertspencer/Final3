using System.ComponentModel.DataAnnotations;

namespace Final3.Models
{
    public class Player
    {
        public int PlayerID { get; set; } // Primary Key

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Rank { get; set; }
    }
}
