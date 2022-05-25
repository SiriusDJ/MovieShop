using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        // showing the empty page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        // when user clicks on Submit/register button
        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login(UserLoginModel model)
        {
            // Model Binding, it looks at the incoming request from client/browser and loot at the info
            // and if it matches with the properties of the model it will get the values automatically
            return View();
        }
    }
}
