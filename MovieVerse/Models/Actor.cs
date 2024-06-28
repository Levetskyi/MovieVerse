using System.ComponentModel.DataAnnotations;
using MovieVerse.Data.Base;

namespace MovieVerse.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

       /* [Required(ErrorMessage ="Profile picture is required")]*/
        public string ProfilePictureURL { get; set; }

       /* [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Full Name must be between 5-50 chars")]*/
        public string FullName { get; set; }

        /*[Required(ErrorMessage = "Bio is required")]*/
        public string Bio { get; set; }

        public List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
