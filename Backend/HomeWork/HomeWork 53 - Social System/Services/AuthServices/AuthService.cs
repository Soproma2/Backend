using HomeWork_53___Social_System.Common;
using HomeWork_53___Social_System.DTOs.Requests;

namespace HomeWork_53___Social_System.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        public Result<string> Register(UserRegisterRequest req)
        {
            return Result<string>.BadRequest("Title is required");
        }

        public Result<string> Login(UserLoginRequest req)
        {
            throw new NotImplementedException();
        }

    }
}
