using HomeWork_60___ASP_Cars.Enums;

namespace HomeWork_60___ASP_Cars.DTOs.Requests
{
    public class RegisterReq
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Buyer;
    }
}
