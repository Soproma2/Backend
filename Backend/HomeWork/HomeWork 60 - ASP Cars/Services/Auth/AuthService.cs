using HomeWork_60___ASP_Cars.Common;
using HomeWork_60___ASP_Cars.Data;
using HomeWork_60___ASP_Cars.DTOs.Requests;
using HomeWork_60___ASP_Cars.Enums;
using HomeWork_60___ASP_Cars.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeWork_60___ASP_Cars.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Result<string> Register(RegisterReq req)
        {
            if (string.IsNullOrWhiteSpace(req.FullName))
                return Result<string>.BadRequest("Full name is required");

            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            if (req.Password.Length < 6)
                return Result<string>.BadRequest("Password must be at least 6 characters");

            if (_context.Users.Any(u => u.Email == req.Email))
                return Result<string>.BadRequest("Email already in use");
           
            if (req.Role == UserRole.Admin)
                return Result<string>.BadRequest("Cannot register as Admin");

            var user = new User
            {
                FullName = req.FullName,
                Email = req.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
                Role = req.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Result<string>.success("Registered successfully", GenerateToken(user));
        }

        public Result<string> Login(LoginReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            var user = _context.Users.FirstOrDefault(u => u.Email == req.Email);
            if (user == null)
                return Result<string>.NotFound("Invalid email or password");

            if (!BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
                return Result<string>.BadRequest("Invalid email or password");

            return Result<string>.success("Login successful", GenerateToken(user));
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
