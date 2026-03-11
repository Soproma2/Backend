using HomeWork_60___ASP_Cars.DTOs.Requests;
using HomeWork_60___ASP_Cars.Common;

namespace HomeWork_60___ASP_Cars.Services.Auth
{
    public interface IAuthService
    {
        Result<string> Register(RegisterReq req);
        Result<string> Login(LoginReq req);
    }
}
