using HomeWork_64_Asp___Todo.Enums;

namespace HomeWork_64_Asp___Todo.Models
{
    public class TodoItem
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Priority Priority { get; set; } = Priority.Medium;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
