using Homework_67_Asp___CompanyEvents.Common;
using Homework_67_Asp___CompanyEvents.DTOs.Responses.Auth;
using Homework_67_Asp___CompanyEvents.DTOs.Requests.Auth;

namespace Homework_67_Asp___CompanyEvents.Services.Auth
{
    public interface IAuthService
    {
        Result<AuthResponse> Register(RegisterRequest request);
        Result<AuthResponse> Login(LoginRequest request);
    }
}
