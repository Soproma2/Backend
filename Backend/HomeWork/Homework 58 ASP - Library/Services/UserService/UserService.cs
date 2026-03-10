using Homework_58_ASP___Library.Common;
using Homework_58_ASP___Library.Data;
using Homework_58_ASP___Library.DTOs.Requests.UserRequests;
using Homework_58_ASP___Library.Enums;
using Homework_58_ASP___Library.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Homework_58_ASP___Library.Services.UserService
{

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public UserService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Result<string> Register(RegisterUserReq req)
        {
            if (string.IsNullOrWhiteSpace(req.FullName))
                return Result<string>.BadRequest("Full name is required");

            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            if (req.Password.Length < 6)
                return Result<string>.BadRequest("Password must be at least 6 characters");

            var exists = _context.Users.Any(m => m.Email == req.Email);
            if (exists)
                return Result<string>.BadRequest("Email already in use");

            var user = new User
            {
                FullName = req.FullName,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
                Role = UserRole.User,
                RegisteredAt = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var token = GenerateToken(user);
            return Result<string>.success("Registered successfully", token);
        }

        public Result<string> Login(LoginUserReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required");

            if (string.IsNullOrWhiteSpace(req.Password))
                return Result<string>.BadRequest("Password is required");

            var user = _context.Users.FirstOrDefault(m => m.Email == req.Email);
            if (user == null)
                return Result<string>.NotFound("Invalid email or password");

            var isValid = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            if (!isValid)
                return Result<string>.BadRequest("Invalid email or password");

            var token = GenerateToken(user);
            return Result<string>.success("Login successful", token);
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
