using HomeWork_55___Student_System___Asp___angular.DTOs.Requests;
using HomeWork_55___Student_System___Asp___angular.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_55___Student_System___Asp___angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult AddStudent(StudentRegisterRequest req)
        {
            var result = _studentService.AddStudent(req);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudents(StudentUpdateRequest req, int id)
        {
            var result = _studentService.UpdateStudent(req, id);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return StatusCode(result.Status, result);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var result = _studentService.GetAllStudents();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var result = _studentService.GetStudentById(id);
            return StatusCode(result.Status, result);
        }
    }
}
