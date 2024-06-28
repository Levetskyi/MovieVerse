using MovieVerse.Models;

namespace MovieVerse.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = [];
            Cinemas = [];
            Actors = [];
        }

        public List<Producer> Producers { get; set; }

        public List<Cinema> Cinemas { get; set; }

        public List<Actor> Actors { get; set; }
    }
}
