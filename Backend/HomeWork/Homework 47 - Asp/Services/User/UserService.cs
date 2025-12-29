using Homework_47___Asp.Data;
using Homework_47___Asp.DTOs.Responses;
using Homework_47___Asp.DTOs.Requests;

namespace Homework_47___Asp.Services.User
{
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db) => _db = db;
        public List<UserResponse>? GetUsers()
        {
            var res = _db.Users.Select(e => new UserResponse()
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email
            }).ToList();

            if(res == null) return null;
            return res;
        }

        public UserResponse RegisterUser(UserCreateReq req)
        {
            Models.User user = new Models.User()
            {
                Name = req.Name,
                Email = req.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password)
            };
            
            _db.Users.Add(user);
            _db.SaveChanges();

            return new UserResponse()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
