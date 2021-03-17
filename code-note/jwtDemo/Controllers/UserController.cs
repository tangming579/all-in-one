using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace jwtDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return BadRequest(new { code = 400, msg = "用户名或密码不能为空" });

            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddSeconds(30);//到期时间

            var role = string.Equals(username, "Admin") ? "Admin" : "Guest";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.Expiration,$"{new DateTimeOffset(expiresAt).ToUnixTimeSeconds()}")//到期时间，按秒数计算
            };
            var key = Encoding.ASCII.GetBytes("Security:Tokens:Key");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Security:Tokens:Issuer",
                Audience = "Security:Tokens:Audience",
                Subject = new ClaimsIdentity(claims),
                Expires = expiresAt,
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { code = 200, msg = "成功", data = tokenHandler.WriteToken(token) });
        }

        [HttpDelete("DeleteUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(string username)
        {
            return Ok(new { code = 200, msg = "成功", data = new { } });
        }

        [HttpGet("Get"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string Get()
        {
            var name = HttpContext.User.Identity.Name;
            return "hello";
        }
    }
}
