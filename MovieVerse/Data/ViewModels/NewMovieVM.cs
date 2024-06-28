using MovieVerse.Data.Enums;

namespace MovieVerse.Models
{
    public class NewMovieVM   
    {
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

        public List<int>? ActorIds { get; set; }

        public int CinemaId { get; set; }
    }
}