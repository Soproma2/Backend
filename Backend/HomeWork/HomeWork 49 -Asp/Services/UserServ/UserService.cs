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
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "User not found"
                };
            }

            if(!BCrypt.Net.BCrypt.Verify(req.CurrentPassword, user.Password))
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Incorrect password"
                };
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(req.NewPassword);
            _db.SaveChanges();

            return new ApiResponse<string>()
            {
                Status = StatusCodes.Status200OK,
                Message = "Password changed successfully"
            };
        }

        public ApiResponse<string> DeleteUser(int userId)
        {
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "User not found"
                };
            }

            _db.Users.Remove(user);
            _db.SaveChanges();

            return new ApiResponse<string>()
            {
                Status= StatusCodes.Status200OK,
                Message = "User deleted successfully"
            };

        }

        public ApiResponse<string> EditUser(int userId, EditUserRequest req)
        {
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return new ApiResponse<string>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "User not found"
                };
            }

            if (!string.IsNullOrWhiteSpace(req.Name))
            {
                user.Name = req.Name;
            }

            _db.SaveChanges();
            return new ApiResponse<string>()
            {
                Status = StatusCodes.Status200OK,
                Message = "User updated successfully"
            };
        }

        public ApiResponse<UserResponse> GetUserById(int userId)
        {
            var user = _db.Users.Find(userId);
            if (user == null)
            {
                return new ApiResponse<UserResponse>()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "User not found"
                };
            }

            return new ApiResponse<UserResponse>()
            {
                Status = StatusCodes.Status200OK,
                Value = new UserResponse()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }
            };
        }
    }
}
