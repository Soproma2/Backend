using HomeWork_49__Asp.Common;
using HomeWork_49__Asp.Data;
using HomeWork_49__Asp.DTOs.Requests;
using HomeWork_49__Asp.DTOs.Responses;

namespace HomeWork_49__Asp.Services.UserServ
{
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db) => _db = db;

        public ApiResponse<string> ChangePassword(int userId, ChangePasswordRequest req)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<string> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<string> EditUser(int userId, EditUserRequest req)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<UserResponse> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
