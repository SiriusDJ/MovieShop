using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // showing the empty page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        // when user clicks on Submit/register button
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            try
            {
                var user = await _accountService.RegisterUser(model);
            }
            catch (ConflictException)
            {
                throw;
                // logging the exceptions later to text  /json files
            }

            return RedirectToAction("Login");
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
