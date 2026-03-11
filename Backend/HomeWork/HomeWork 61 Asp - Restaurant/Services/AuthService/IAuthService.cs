using HomeWork_61_Asp___Restaurant.Common;
using HomeWork_61_Asp___Restaurant.DTOs.Requests;

namespace HomeWork_61_Asp___Restaurant.Services.AuthService
{
    public interface IAuthService
    {
        Result<string> Register(RegisterReq req);
        Result<string> Login(LoginReq req);
    }
}
