using System.ComponentModel.DataAnnotations;

namespace Final3.Models
{
    public class Game
    {
        public int GameID { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
