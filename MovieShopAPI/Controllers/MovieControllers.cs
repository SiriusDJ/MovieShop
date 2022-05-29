using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts;
using ApplicationCore.Contracts.Services;

namespace MovieShopAPI.Controllers
{
    // Use Attribute based routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;

        }
        // api/movies/top-grossing
        [Route("top-grossing")]
        [HttpGet]
        public async Task<IActionResult> TopGrossing()
        {
            var movies = await _movieService.GetTop30GrossingMovies();
            // return JSON data and always return proper HTTP status code
            if (movies == null || !movies.Any())
            {
                // 404
                return NotFound(new { error = "No Movies Found" });

            }
            // ASP.NET Core API will automatically serialize C# objects in to JSON Objects
            // System.Text.Json vs Newtonsoft.json 
            // 
            // 200
            return Ok(movies);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound(new { error = "No Movies Found" });
            }
            return Ok(movie);
        }
    }
}
