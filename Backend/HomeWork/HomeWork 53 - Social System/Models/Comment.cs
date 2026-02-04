using HomeWork_53___Social_System.Common;

namespace HomeWork_53___Social_System.Models
{
    public class Comment : BaseEntity
    {
        public string text { get; set; }
        
        public int PostId { get; set; }
        public Post post { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }
    }
}
