using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtSample.Api.Controllers
{
    public class AuthController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return Ok(GenerateJSONWebToken());
        }

        private string GenerateJSONWebToken()
        {
            var claims = new List<Claim>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mobinmahdi.ir/Key"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "mobinmahdi.ir/Issuer",
                audience: "mobinmahdi.ir/Audience",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}