using HomeWork_55___Student_System___Asp___angular.Common;
using HomeWork_55___Student_System___Asp___angular.DTOs.Responses;

namespace HomeWork_55___Student_System___Asp___angular.Services
{
    public interface IStudentService
    {
        Result<string> AddStudent();
        Result<string> UpdateStudent();
        Result<string> DeleteStudent();
        Result <List<StudentResponse>> GetAllStudent();
        Result<StudentResponse> GetStudentById(int id);
    }
}
