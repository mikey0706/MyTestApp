using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MyTestApp.Repository;
using MyTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        private readonly UnitOfWork _unit;

        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _unit = new UnitOfWork();
            _config = config;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] UserViewModel data)
        {
            IActionResult response = Unauthorized();
            if (data != null)
            {

                var user = _unit.UserData().CheckUser(data.Login, data.Password);
                if (user == true)
                {

                    var tokenString = GenerateJSONWebToken();

                    response = Ok(new { Token = tokenString, Message = "Success" });
                }
                return response;
            }
            return response;
        }


        [HttpGet(nameof(UserList))]
        public IEnumerable<UserOutputModel> UserList()
        {
            if (User.Identity.IsAuthenticated)
            {
                var users = _unit.UserData().GetAllUsers();
                return users.Select(n => new UserOutputModel(n.Name, n.UserName)).ToList();
            }
            return new List<UserOutputModel>();

        }


    }
}
