using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;

namespace HomeWork_53___Social_System.Services.AuthServices
{
    public interface IAuthService
    {
        Result<string> Register(RegisterReq req);
        Result<string> Login(LoginReq req);
    }
}
