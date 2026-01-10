using HomeWork_49__Asp.Data;

namespace HomeWork_49__Asp.Services.UserServ
{
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db) => _db = db;
    }
}
