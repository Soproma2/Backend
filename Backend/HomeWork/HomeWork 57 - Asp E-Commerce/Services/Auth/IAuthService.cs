using HomeWork_57___Asp_E_Commerce.Common;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Post;
using HomeWork_57___Asp_E_Commerce.DTOs.Requests.Update;

namespace HomeWork_57___Asp_E_Commerce.Services.Auth
{
    public interface IAuthService
    {
        Result<string> Register(UserRegisterRequest req);
        Result<string> VerifyEmail(VerifyEmailRequest req);
        Result<string> Login(UserLoginRequest req);
        Result<string> Logout();
    }
}
