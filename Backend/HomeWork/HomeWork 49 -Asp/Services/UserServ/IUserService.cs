using HomeWork_49__Asp.Common;
using HomeWork_49__Asp.DTOs.Requests;
using HomeWork_49__Asp.DTOs.Responses;

namespace HomeWork_49__Asp.Services.UserServ
{
    public interface IUserService
    {
        ApiResponse<string> EditUser(int userId, EditUserRequest req);
        ApiResponse<UserResponse> GetUserById(int userId);
        ApiResponse<string> DeleteUser(int userId);
        ApiResponse<string> ChangePassword(int userId, ChangePasswordRequest req);
    }
}
