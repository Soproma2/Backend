using HomeWork_56___Todo___Extension.Common;
using HomeWork_56___Todo___Extension.Data;
using HomeWork_56___Todo___Extension.DTOs.Requests;
using HomeWork_56___Todo___Extension.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeWork_56___Todo___Extension.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public AuthService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Result<string> Register(RegisterReq req)
        {
            if (string.IsNullOrWhiteSpace(req.UserName))
                return Result<string>.BadRequest("Username is required");

            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            if (req.Password.Length < 6)
                return Result<string>.BadRequest("Password must be at least 6 characters");

            if (_context.Users.Any(u => u.Email == req.Email))
                return Result<string>.BadRequest("Email already in use");

            if (_context.Users.Any(u => u.UserName == req.UserName))
                return Result<string>.BadRequest("Username already taken");

            var user = new User
            {
                UserName = req.UserName,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password)
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

            if (!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
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
            new Claim(ClaimTypes.Name, user.UserName)
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
