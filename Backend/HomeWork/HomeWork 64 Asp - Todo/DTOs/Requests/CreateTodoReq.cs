using HomeWork_64_Asp___Todo.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeWork_64_Asp___Todo.DTOs.Requests
{
    public class CreateTodoReq
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; } = Priority.Medium;
        public DateTime? DueDate { get; set; }
    }
}
