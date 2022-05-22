using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            // create repositories => Data access logic
            // services => business logic
            // Controller action methods => services methods => Repository motheods => SQL database
            // get the mode data from the services and send the data to the views (M)

            // CPU bound operation => Pi, loan calculator, image processing
            // I/O bound operation => database calls, file, images, videos

            // Network speed, SQL Server => Query, Server Memory can affect the speed of the following code
            // T1(Thread 1) is just waiting
            var movie = await _movieService.GetMovieDetails(id);
            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View("pagedMovies", pagedMovies);
        }
    }
}
