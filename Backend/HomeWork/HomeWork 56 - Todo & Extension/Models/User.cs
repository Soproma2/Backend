using HomeWork_56___Todo___Extension.Common;

namespace HomeWork_56___Todo___Extension.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TodoItem> Todos { get; set; } = new();
    }
}
