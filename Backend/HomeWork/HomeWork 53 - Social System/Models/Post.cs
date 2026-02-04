using HomeWork_53___Social_System.Common;

namespace HomeWork_53___Social_System.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string description { get; set; }
        public string imgUrl { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }

        public List<Like> Likes { get; set; } = new List<Like>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
