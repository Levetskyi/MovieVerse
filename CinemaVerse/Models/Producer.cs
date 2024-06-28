using CinemaVerse.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CinemaVerse.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}