using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {

        private readonly ILogger<MoviesController> _logger;
        private readonly ICastService _castService;

        public CastController(ILogger<MoviesController> logger, ICastService castService)
        {
            _logger = logger;
            _castService = castService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var casts = await _castService.GetCastDetails(id);
            return View(casts);
        }
    }
}
