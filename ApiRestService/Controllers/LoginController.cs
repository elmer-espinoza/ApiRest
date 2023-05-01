using ApiRestService.Models;
using ApiRestService.Controllers;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics.Eventing.Reader;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiRestService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [NonAction]
        [Route ("Hola")]
        public IActionResult Hola()
        {
            return Ok("Hola");
        }

        [HttpGet]
        [NonAction]
        [Route  ("HolaMundo")]
        public string HolaMundo ()
        {
            return "Hola Mundo";
        }

        [HttpPost]
        [Route("AuthToken")]
        //public IActionResult Login (string username, string password)
        public IActionResult AuthToken(Login login)
        {
            var Auth = Autenticate(login); 
            if (Auth != null)
            {
                //return Ok("Usuario " + login.Username + " logueado en el sistema");
                var token = GenerateJWT(Auth);
                return Ok(token);

            } 
            else
            {
                return BadRequest("Usuario " + login.Username + " no pudo validarse en el sistema");
              //return NotFound("Usuario " + login.Username + " no pudo validarse en el sistema");
            }
            
        }

        //[HttpPost]
        //[Route("Auth")]
        private User Autenticate(Login login)
        {
            try
            {
                var currentuser = (new SqlConnection(new DataBase().StringConnection())).Query<User>("select * from ApiRestuser where username = @username and password COLLATE Latin1_General_CS_AS = @password", new { @username = login.Username, @password = login.Password }).First();
                return currentuser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(480).ToString("yyyy-MM-dd HH:mm:ss"))
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(480),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
