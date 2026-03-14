using HomeWork_65_Asp___GameShop.Common;
using HomeWork_65_Asp___GameShop.DTOs.Requests;

namespace HomeWork_65_Asp___GameShop.Services.Auth
{
    public interface IAuthService
    {
        Result<string> Register(RegisterReq req);
        Result<string> Login(LoginReq req);
    }
}
