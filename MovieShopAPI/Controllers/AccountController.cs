using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await _accountService.LoginUser(model.Email, model.Password);

            
            // return a token..
            // JWT Json Web Token
            // iOS, Android app or Web App (Angular or React)
            // Once Client Received the token, it needs to store in the
            // iOS - Device
            // browser - localstorage
            // android - device
            // show all the movies purchased?
            // send the token in the http header
            // API will validate that token and then send the data back
            // authorize
            var jwtToken = GenerateJwtToken(user);
            
            return Ok(new {token = jwtToken});
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register( [FromBody] UserRegisterModel model)
        {
            var user = _accountService.RegisterUser(model);
            return Ok(user);

        }

        private string GenerateJwtToken(UserLoginResponseModel user)
        {
            // create claims so that we have those in the payload

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.LastName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim("Country","USA"),
                new Claim("Language", "English")

            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // specify the secret KEY
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secretKey"]));

            // specify the algorithm
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // how long the token is valid
            var tokenExpiration = DateTime.UtcNow.AddHours(2);

            

            // create an object for above details for the token

            var tokenDetails = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = tokenExpiration,
                SigningCredentials = credentials,
                Issuer = "MovieShop, Inc",
                Audience = "MovieShop Clients"
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedJwt = tokenHandler.CreateToken(tokenDetails);
            return tokenHandler.WriteToken(encodedJwt);

        }
    }
}
