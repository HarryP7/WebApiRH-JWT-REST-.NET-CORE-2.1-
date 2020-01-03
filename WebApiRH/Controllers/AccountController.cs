using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiRH.Models.Services;
using WebApiRH.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApiRH.Models.ViewModel;
using WebApiRH.Models.Helpers;

namespace WebApiRH.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfiguration config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            this.userService = userService;
            this.config = config;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Create([FromBody] RegisterUserViewModel model)
        {
            model.Role = (int)Role.user;
            try
            {
                var user = userService.Create((User)model, model.Password);
                var tokenString = GetToken(user);
                return Ok(new
                {
                    token = tokenString,
                    userLogin = user
                });
            }
            catch (AppException e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
            catch
            {
                return BadRequest(new
                {
                    message = "Произошла ошибка, попробуйте позже"
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult Authenticate([FromBody] AuthUserViewModel model)
        {
            if (model == null || model.Login == null || model.Password == null)
                return BadRequest(new { message = "Логин или пароль не валидны" });

            var user = userService.Authenticate(model.Login, model.Password);

            if (user == null)
                return BadRequest(new { message = "Логин или пароль не валидны" });
                       
            var tokenString = GetToken(user);

            return Ok(new
            {
                token = tokenString,
                userLogin = user
            });
        }

        // POST api/auth/address
        [HttpPost("address")]
        public IActionResult AddAdress([FromBody] AddAdressModel model)
        {
            try
            {
                var user = userService.Get(model.Fk_User);
                if (user == null)
                {
                    return BadRequest();
                }
                if (model.Fk_Home == null)
                {
                    return BadRequest();
                }
                if (model.Appartment == 0)
                {
                    return BadRequest();
                }
                userService.Update(user, model.Fk_Home, model.Appartment, model.Address);
                return Ok(new
                {
                    userLogin = user
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    message = "На сервере произошла ошибка, попробуйте позже"
                });
            }
        }

        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Config:SecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Uid),
                    new Claim(ClaimTypes.Role, user.Fk_Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}