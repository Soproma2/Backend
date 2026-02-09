using HomeWork_57___Asp_E_Commerce.Common;

namespace HomeWork_57___Asp_E_Commerce.Models
{
    public class Profile : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
