using CinemaVerse.Data.Base;
using CinemaVerse.Data.ViewModels;
using CinemaVerse.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaVerse.Data.Services
{
    public class MoviesService(AppDbContext context) : EntityBaseRepository<Movie>(context), IMovieService
    {

        private readonly AppDbContext _context = context;

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Category = data.Category,
                LongDescription = data.LongDescription,
                PosterImageURL = data.PosterImageURL,
                Year = data.Year,
                Country = data.Country,
                Language = data.Language,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Duration = data.Duration,
                AgeRating = data.AgeRating,
                Price = data.Price,
                CinemaId = data.CinemaId,
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(a => a.Actor_Movies)
                .ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id ==id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Category = data.Category;
                dbMovie.LongDescription = data.LongDescription;
                dbMovie.PosterImageURL = data.PosterImageURL;
                dbMovie.Year = data.Year;
                dbMovie.Country = data.Country;
                dbMovie.Language = data.Language;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.Duration = data.Duration;
                dbMovie.AgeRating = data.AgeRating;
                dbMovie.Price = data.Price;
                dbMovie.CinemaId = data.CinemaId;
                
                await _context.SaveChangesAsync();
            }

            
        }
    }
}