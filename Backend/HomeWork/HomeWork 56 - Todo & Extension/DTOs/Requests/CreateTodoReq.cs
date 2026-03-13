using HomeWork_56___Todo___Extension.Enums;

namespace HomeWork_56___Todo___Extension.DTOs.Requests
{
    public class CreateTodoReq
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; } = Priority.Medium;
        public DateTime? DueDate { get; set; }
    }
}
