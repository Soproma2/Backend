using HomeWork_51___Asp_JWT.Common;
using HomeWork_51___Asp_JWT.Data;
using HomeWork_51___Asp_JWT.DTOs;
using HomeWork_51___Asp_JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeWork_51___Asp_JWT.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        public AuthService(DataContext db) => _db = db;
        public ApiResponse<UserRequest> Register(RegisterDto req)
        {
            if (string.IsNullOrEmpty(req.Username))
            {
                return new ApiResponse<UserRequest>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Name is required"
                };
            }

            if (string.IsNullOrEmpty(req.Email))
            {
                return new ApiResponse<UserRequest>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email is required"
                };
            }

            if (!req.Email.Contains("@") && !req.Email.Contains("."))
            {
                return new ApiResponse<UserRequest>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email need @ and ."
                };
            }

            if (_db.Users.Any(e => e.Email == req.Email))
            {
                return new ApiResponse<UserRequest>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email already exists"
                };
            }

            if (string.IsNullOrEmpty(req.Password))
            {
                return new ApiResponse<UserRequest>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Password is required"
                };
            }

            User user = new User()
            {
                Username = req.Username,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return new ApiResponse<UserRequest>()
            {
                Status = StatusCodes.Status201Created,
                Message = "User registered successfully."
            };
        }

        public ApiResponse<string> Login(LoginDto req)
        {
            var user = _db.Users.FirstOrDefault(e => e.Email == req.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Email or password is incorrect",
                    Value = null
                };
            }

            string token = GenerateJwtToken(user);

            return new ApiResponse<string>()
            {
                Status = StatusCodes.Status200OK,
                Value = token
            };
        }

        public ApiResponse<UserRequest> GetUserByid(int userId)
        {
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return new ApiResponse<UserRequest>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "User Not Found",
                    Value = null
                };
            }

            return new ApiResponse<UserRequest>
            {
                Status = StatusCodes.Status200OK,
                Value = new UserRequest()
                {
                    Id = userId,
                    Username= user.Username,
                    Email = user.Email,
                }

            };
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_72548136437137467913657163756237"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "auth_domain_api.com",
                audience: "auth_frontend.com",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
