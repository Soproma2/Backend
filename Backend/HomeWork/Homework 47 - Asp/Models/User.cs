using System.Collections.Generic;

namespace Homework_47___Asp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    }
}
