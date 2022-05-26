using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //show all the movies purchased by currently logged in user

        [HttpGet]

        public async Task<IActionResult> Purchases()
        {
            // first whether user is logged in 
            // if not logged in: redirect login page; 
            // 10:00 AM user email/password => something that can be used at 10:05
            // 10:05 he/she calls user/purchases
            // create cookie at 10, authentication cookie that can be used across http request and check whether 
            // user is logged in or not
            // cookie -> location? client/browser
            // Http Request is independent of each other
            // userid, go to purchase table and get all the movies purchased
            // display as movie cards, user movie card partial view
            //var isLoggedIn = this.HttpContext.User.Identity.IsAuthenticated;
            //if (!isLoggedIn)
            //{
            //    //redirect to login page

            //}
            //var userId = this.HttpContext.User.Claims.FirstOrDefault(x => x.ValueType == ClaimType.Identifiers)?.Value;
            // send it to database

            // Filters in ASP.NET
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            // call the UserService -> GetMoviesPurchasedByUser(int userId) -> Purchased Movies

            //var data = this.HttpContext.Request.Cookies["MovieShopAuthcookie"];
            // decrypt the cookie and get hte userid from claims and expiration time from the cookie
            // use the userid to go to database and get the movies purchased

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View();
        }

        public async Task<IActionResult> Reviews()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View();
        }
    }
}
