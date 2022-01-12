using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebLogin.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost,Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if(user == null)
            {
                return BadRequest("Invalid client request");
            }

            if(user.UserName == "johndoe" && user.Password == "def@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOption = new JwtSecurityToken(
              issuer: "https://localhost:44308",
              audience: "https://localhost:44308",
              claims:new List<Claim>(),
              expires:DateTime.Now.AddMinutes(5),
              signingCredentials:signinCredentials

              );
                var tokenString=new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return Ok(new {Token = tokenString});
            }
            else
            {
                return Unauthorized();
            }
          
        }
    }
}
//https://code-maze.com/authentication-aspnetcore-jwt-2/