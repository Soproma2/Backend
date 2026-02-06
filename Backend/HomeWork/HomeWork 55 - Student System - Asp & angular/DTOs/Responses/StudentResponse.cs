namespace HomeWork_55___Student_System___Asp___angular.DTOs.Responses
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
