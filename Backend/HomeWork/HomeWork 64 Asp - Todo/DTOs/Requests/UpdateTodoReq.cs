using HomeWork_64_Asp___Todo.Enums;

namespace HomeWork_64_Asp___Todo.DTOs.Requests
{
    public class UpdateTodoReq
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
