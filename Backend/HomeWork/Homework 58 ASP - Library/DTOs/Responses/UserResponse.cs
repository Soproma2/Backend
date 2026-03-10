namespace Homework_58_ASP___Library.DTOs.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredAt { get; set; };
    }
}
