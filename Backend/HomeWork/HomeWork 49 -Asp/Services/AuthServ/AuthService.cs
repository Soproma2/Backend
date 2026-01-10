using HomeWork_49__Asp.Common;
using HomeWork_49__Asp.Data;
using HomeWork_49__Asp.DTOs.Requests;
using HomeWork_49__Asp.DTOs.Responses;
using HomeWork_49__Asp.Models;

namespace HomeWork_49__Asp.Services.AuthServ
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        public AuthService(DataContext db) => _db = db;

        public ApiResponse<string> Register(RegisterRequest req)
        {
            if (string.IsNullOrEmpty(req.Name))
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Name is required"
                };
            }

            if (string.IsNullOrEmpty(req.Email))
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email is required"
                };
            }

            if(_db.Users.Any(e=>e.Email == req.Email))
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Email already exists"
                };
            }

            if (string.IsNullOrEmpty(req.Password))
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Password is required"
                };
            }

            User user = new User()
            {
                Name = req.Name,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return new ApiResponse<string>()
            {
                Status = StatusCodes.Status201Created,
                Message = "User registered successfully."
            };
        }

        public ApiResponse<UserResponse> Login(LoginRequest req)
        {
            var user = _db.Users.FirstOrDefault(e=>e.Email == req.Email);

            if(user == null)
            {
                return new ApiResponse<UserResponse>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Email or password is incorrect",
                    Value = null
                };
            }

            if(!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
            {
                return new ApiResponse<UserResponse>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Email or password is incorrect",
                    Value = null
                };
            }

            return new ApiResponse<UserResponse>()
            {
                Status = StatusCodes.Status200OK,
                Message = "User loged in successfully.",
                Value = new UserResponse()
                {
                    Name = user.Name,
                    Email = user.Email,
                }
            };
        }

    }
}
