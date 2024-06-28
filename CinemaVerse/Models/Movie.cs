using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinemaVerse.Data.Base;
using CinemaVerse.Data.Enums;

namespace CinemaVerse.Models
{
    public class Movie : IEntityBase    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public MovieCategory Category { get; set; }

        public string LongDescription { get; set; }

        public string PosterImageURL { get; set; }

        public int Year { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Duration { get; set; }

        public int AgeRating { get; set; }

        public double Price { get; set; }

        public List<Actor_Movie>? Actor_Movies { get; set; }

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public Cinema? Cinema { get; set; }
    }
}