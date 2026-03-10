using Homework_58_ASP___Library.Common;
using Homework_58_ASP___Library.DTOs.Requests.UserRequests;

namespace Homework_58_ASP___Library.Services.UserService
{
    public interface IUserService
    {
            Result<string> Register(RegisterUserReq req);
            Result<string> Login(LoginUserReq req);
        
    }
}
