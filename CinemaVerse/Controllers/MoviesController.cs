using CinemaVerse.Data.Services;
using Microsoft.AspNetCore.Mvc;
using CinemaVerse.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaVerse.Controllers
{
    public class MoviesController(IMovieService service) : Controller
    {
        private readonly IMovieService _service = service;

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResults = allMovies.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                || n.LongDescription.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResults);
            }


            return View("Index", allMovies);
        }

        public async Task<IActionResult> List()
        {
            var allMovies = await _service.GetAllAsync();
            return View(allMovies);
        }

        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

            return View();
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movieViewModel)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

                return View(movieViewModel);
            }

            await _service.AddNewMovieAsync(movieViewModel);
            return RedirectToAction(nameof(Index));
        }

        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            return View(movieDetails);
        }

        //Get: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Category = movieDetails.Category,
                LongDescription = movieDetails.LongDescription,
                PosterImageURL = movieDetails.PosterImageURL,
                Year = movieDetails.Year,
                Country = movieDetails.Country,
                Language = movieDetails.Language,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                Duration = movieDetails.Duration,
                AgeRating = movieDetails.AgeRating,
                Price = movieDetails.Price,
                CinemaId = movieDetails.CinemaId,
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

            return View(response);
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(List));
        }

        //Get: Movies/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            return View(movieDetails);
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}