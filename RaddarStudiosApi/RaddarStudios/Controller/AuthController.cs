using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Raddar.ProductsApi.Application.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RaddarStudios.Controller
{
    [ApiController]
    [Route("/api/")]
    public class AuthController: ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            
                if (login.Username != "admin" || login.Password != "123")
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "Admin"),
                };

                var jwtSettings = _configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "RaddarStudios-api",
                    audience: "RaddarStudios-client",
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                
                return Ok(new { token = tokenString });
        }
    }

    public class LoginRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}