using HomeWork_49__Asp.Common;
using HomeWork_49__Asp.DTOs.Requests;
using HomeWork_49__Asp.DTOs.Responses;


namespace HomeWork_49__Asp.Services.AuthServ
{
    public interface IAuthService
    {
        ApiResponse<string> Register(RegisterRequest req);
        ApiResponse<UserResponse> Login(LoginRequest req);
    }
}
