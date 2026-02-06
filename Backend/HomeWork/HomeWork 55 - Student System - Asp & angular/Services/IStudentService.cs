using HomeWork_55___Student_System___Asp___angular.Common;
using HomeWork_55___Student_System___Asp___angular.DTOs.Requests;
using HomeWork_55___Student_System___Asp___angular.DTOs.Responses;

namespace HomeWork_55___Student_System___Asp___angular.Services
{
    public interface IStudentService
    {
        Result<string> AddStudent(StudentRegisterRequest req);
        Result<string> UpdateStudent(StudentUpdateRequest req, int StudentId);
        Result<string> DeleteStudent(int StudentId);
        Result <List<StudentResponse>> GetAllStudents();
        Result<StudentResponse> GetStudentById(int id);
    }
}
