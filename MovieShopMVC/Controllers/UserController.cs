using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }
    }
}
