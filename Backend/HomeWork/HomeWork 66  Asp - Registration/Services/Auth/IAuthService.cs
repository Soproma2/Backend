using HomeWork_66__Asp___Registration.DTOs.Requests;
using HomeWork_66__Asp___Registration.DTOs.Responses;
using HomeWork_66__Asp___Registration.Common;

namespace HomeWork_66__Asp___Registration.Services.Auth
{
    public interface IAuthService
    {
        Result<string> Register(RegisterReq req);
        Result<string> Login(LoginReq req);
        Result<string> VerifyEmail(VerifyEmailReq req);
        Result<string> ForgotPassword(ForgotPasswordReq req);
        Result<string> ResetPassword(ResetPasswordReq req);
        Result<UserResponse> GetMe(int userId);
    }
}
