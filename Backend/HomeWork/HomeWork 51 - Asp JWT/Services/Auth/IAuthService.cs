using HomeWork_51___Asp_JWT.Common;
using HomeWork_51___Asp_JWT.DTOs;
using HomeWork_51___Asp_JWT.Models;

namespace HomeWork_51___Asp_JWT.Services.Auth
{
    public interface IAuthService
    {
        ApiResponse<UserRequest> Register(RegisterDto req);
        ApiResponse<string> Login(LoginDto req);
        ApiResponse<UserRequest> GetUserByid(int userId);
        string GenerateJwtToken(User user);
    }
}
