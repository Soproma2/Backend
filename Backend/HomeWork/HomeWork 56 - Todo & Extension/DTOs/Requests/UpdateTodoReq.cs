using HomeWork_56___Todo___Extension.Enums;

namespace HomeWork_56___Todo___Extension.DTOs.Requests
{
    public class UpdateTodoReq
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
