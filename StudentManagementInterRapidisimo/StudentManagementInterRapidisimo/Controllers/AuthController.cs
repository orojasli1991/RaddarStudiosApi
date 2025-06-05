using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagementInterRapidisimo.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementInterRapidisimo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IStudentRepository _studentRepository;

        public AuthController(IConfiguration configuration, IStudentRepository studentRepository)
        {
            _configuration = configuration;
            _studentRepository = studentRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest  request) {
            var user = await _studentRepository.GetByEmail(request.Username);
            if (user == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }
            var token = GenerateJwtToken(request.Username, user.Id);
            return Ok(new { token });
        }

        private string GenerateJwtToken(string username, int userid)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim("userId", userid.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
