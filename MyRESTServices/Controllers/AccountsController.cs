using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Helpers;
using MyRESTServices.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppSetting _appSetting;
        private readonly IUserBLL _user;

        public AccountsController(IOptions<AppSetting> appSetting, IUserBLL userBLL)
        {
            _appSetting = appSetting.Value;
            _user = userBLL;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(AuthProcessViewModel entity)
        {
            var result = await _user.Login(entity.Username,entity.Password);
            if (result != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, entity.Username));

                foreach (var role in result.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new UserWithToken
                {
                    UserName = entity.Username,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post(UserCreateDTO userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest();
            }

            try
            {
                await _user.Insert(userCreate);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
