using Homework_47___Asp.DTOs.Requests;
using Homework_47___Asp.DTOs.Responses;
namespace Homework_47___Asp.Services.User
{
    public interface IUserService
    {
        List<UserResponse>? GetUsers();
        UserResponse RegisterUser();
    }
}
