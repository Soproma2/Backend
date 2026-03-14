using HomeWork_65_Asp___GameShop.Enums;

namespace HomeWork_65_Asp___GameShop.DTOs.Requests
{
    public class RegisterReq
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}
