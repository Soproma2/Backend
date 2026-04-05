using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.Data;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Auth;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Auth;
using Homework_67_Asp___CompanyEvents.Enums;
using Homework_67_Asp___CompanyEvents.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Homework_67_Asp___CompanyEvents.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public Result<AuthResponse> Register(RegisterRequest request)
        {
            if (_db.Users.Any(u => u.Email == request.Email))
                return Result.Failure<AuthResponse>("Email უკვე გამოყენებულია.");

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = UserRole.User
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            var token = GenerateToken(user);
            return Result.Success(new AuthResponse(token, user.FullName, user.Email, user.Role.ToString()));
        }

        public Result<AuthResponse> Login(LoginRequest request)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == request.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Result.Failure<AuthResponse>("Email ან პაროლი არასწორია.");

            var token = GenerateToken(user);
            return Result.Success(new AuthResponse(token, user.FullName, user.Email, user.Role.ToString()));
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
