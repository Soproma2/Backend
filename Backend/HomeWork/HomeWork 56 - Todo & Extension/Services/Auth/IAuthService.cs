using HomeWork_56___Todo___Extension.Common;
using HomeWork_56___Todo___Extension.DTOs.Requests;

namespace HomeWork_56___Todo___Extension.Services.Auth
{
    public interface IAuthService
    {
        Result<string> Register(RegisterReq req);
        Result<string> Login(LoginReq req);
    }
}
