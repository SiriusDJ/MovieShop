
using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            if (!ModelState.IsValid)
            {
                return View();
            }


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





        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Login(UserLoginModel model)
        {
            // Model Binding, it looks at the incoming request from client/browser and loot at the info
            // and if it matches with the properties of the model it will get the values automatically

            // 10:00 AM => email/pw => create auth cookie (20min)
            // 10:05 AM => user/purchases
            // Cookie based authentication
            // 1:00 PM => user/purchases, redirect to the login page

            // claims => things that represent you
            // DL -> FirstName, LastName, 
            // Licence -> For entering some special building
            // Claim called Admin Role to enter admin pages
            try
            {
                var user = await _accountService.LoginUser(model.Email, model.Password);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.LastName),
                    new Claim(ClaimTypes.Surname, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToShortDateString()),
                    new Claim("Language","English")
                };

                // All claims contributes to your identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // create the cookie with above claims

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Tell ASP.NET, how long the cookie is gonna be valid
                // Name of the cookie 
                return LocalRedirect("~/");

                if (user != null)
                {
                    //redirect to home page
                    return LocalRedirect("~/");
                }
            }
            catch (Exception)
            {
                return View();
                throw;
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        
    }

}
