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
        public IActionResult Details(int id)
        {

            // create repositories => Data access logic
            // services => business logic
            // Controller action methods => services methods => Repository motheods => SQL database
            // get the mode data from the services and send the data to the views (M)

            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }
    }
}
