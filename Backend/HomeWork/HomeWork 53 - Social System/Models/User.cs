using HomeWork_53___Social_System.Common;

namespace HomeWork_53___Social_System.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? verificationCode  { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;

        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> comments { get; set; } = new List<Comment>();
    }
}
