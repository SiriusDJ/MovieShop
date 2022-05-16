using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
