using HomeWork_53___Social_System.Common;

namespace HomeWork_53___Social_System.Models
{
    public class Like : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
