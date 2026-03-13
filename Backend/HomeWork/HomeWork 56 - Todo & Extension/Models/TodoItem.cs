using HomeWork_56___Todo___Extension.Common;
using HomeWork_56___Todo___Extension.Enums;

namespace HomeWork_56___Todo___Extension.Models
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Priority Priority { get; set; } = Priority.Medium;
        public DateTime? DueDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
