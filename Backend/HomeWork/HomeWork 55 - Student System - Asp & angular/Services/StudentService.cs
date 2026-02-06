using HomeWork_55___Student_System___Asp___angular.Common;
using HomeWork_55___Student_System___Asp___angular.Data;
using HomeWork_55___Student_System___Asp___angular.DTOs.Requests;
using HomeWork_55___Student_System___Asp___angular.DTOs.Responses;
using HomeWork_55___Student_System___Asp___angular.Models;

namespace HomeWork_55___Student_System___Asp___angular.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _db;
        public StudentService(DataContext db)
        {
            _db = db;
        }

        public Result<string> AddStudent(StudentRegisterRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.FirstName))
                return Result<string>.BadRequest("FirstName is required!");
            if (string.IsNullOrWhiteSpace(req.LastName))
                return Result<string>.BadRequest("LastName is required!");
            if (string.IsNullOrWhiteSpace(req.Email))
                return Result<string>.BadRequest("Email is required!");
            if (string.IsNullOrWhiteSpace(req.Address))
                return Result<string>.BadRequest("Address is required!");
            if (string.IsNullOrWhiteSpace(req.PhoneNumber))
                return Result<string>.BadRequest("PhoneNumber is required!");
            if (req.DateOfBirth == default)
                return Result<string>.BadRequest("DateOfBirth is required");

            Student student = new Student()
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
                Address = req.Address,
                PhoneNumber = req.PhoneNumber,
                DateOfBirth = req.DateOfBirth
            };

            _db.Students.Add(student);
            _db.SaveChanges();

            return Result<string>.success("Student added Successfully", null);
        }
        public Result<string> UpdateStudent(StudentUpdateRequest req, int StudentId)
        {
            var student = _db.Students.Find(StudentId);

            if (student == null) return Result<string>.NotFound("Student not found");

            if (!string.IsNullOrWhiteSpace(req.FirstName)) student.FirstName = req.FirstName;
            if (!string.IsNullOrWhiteSpace(req.LastName)) student.LastName = req.LastName;
            if (!string.IsNullOrWhiteSpace(req.Email)) student.Email = req.Email;
            if (!string.IsNullOrWhiteSpace(req.Address)) student.Address = req.Address;
            if (!string.IsNullOrWhiteSpace(req.PhoneNumber)) student.PhoneNumber = req.PhoneNumber;
            if (req.DateOfBirth.HasValue) student.DateOfBirth = req.DateOfBirth.Value;
            student.UpdatedAt = DateTime.Now;

            _db.SaveChanges();
            return Result<string>.success("Student Updated Successfully.", null);
        }

        public Result<string> DeleteStudent(int StudentId)
        {
            var student = _db.Students.Find(StudentId);

            if (student == null) return Result<string>.NotFound("Student not found.");

            _db.Students.Remove(student);
            _db.SaveChanges();

            return Result<string>.success("Student Deleted Successfully.", null);
        }

        public Result<List<StudentResponse>> GetAllStudent()
        {
            var students = _db.Students.ToList();

            if (!students.Any()) return Result<List<StudentResponse>>.NotFound("Students not found.");
            var result = students.Select(s=>new StudentResponse()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                DateOfBirth = s.DateOfBirth,
                EnrollmentDate = s.EnrollmentDate,
                UpdatedAt = s.UpdatedAt
            }).ToList();

            return Result<List<StudentResponse>>.success(null, result);
        }

        public Result<StudentResponse> GetStudentById(int id)
        {
            var student = _db.Students.Find(id);

            if (student == null) return Result<StudentResponse>.NotFound("Student not found.");

            var result = new StudentResponse()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Address = student.Address,
                PhoneNumber = student.PhoneNumber,
                DateOfBirth = student.DateOfBirth,
                EnrollmentDate = student.EnrollmentDate,
                UpdatedAt = student.UpdatedAt
            };

            return Result<StudentResponse>.success(null, result);
        }

    }
}
