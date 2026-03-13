using HomeWork_56___Todo___Extension.Enums;

namespace HomeWork_56___Todo___Extension.DTOs.Responses
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public Priority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
