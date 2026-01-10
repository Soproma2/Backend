using HomeWork_49__Asp.Data;

namespace HomeWork_49__Asp.Services.AuthServ
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        public AuthService(DataContext db) => _db = db;
    }
}
