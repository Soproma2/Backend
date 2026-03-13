using HomeWork_62_University_EF_Core.Data;
using HomeWork_62_University_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Services
{
    internal class CourseService
    {
        private readonly UniversityDbContext _context;

        public CourseService(UniversityDbContext context)
        {
            _context = context;
        }

        // კურსის დამატება
        public async Task<Course> CreateCourseAsync(
            string courseName, string courseCode,
            int credits, string semester, int facultyId)
        {
            var course = new Course
            {
                CourseName = courseName,
                CourseCode = courseCode,
                Credits = credits,
                Semester = semester,
                FacultyId = facultyId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        // კურსზე სახელმძღვანელოს მიბმა (Many-to-Many)
        public async Task AddTextbookAsync(int courseId, int textbookId, bool isMandatory)
        {
            var ct = new CourseTextbook
            {
                CourseId = courseId,
                TextbookId = textbookId,
                IsMandatory = isMandatory
            };

            _context.CourseTextbooks.Add(ct);
            await _context.SaveChangesAsync();
        }

        // კურსის სტუდენტები
        public async Task<List<Enrollment>> GetCourseStudentsAsync(int courseId)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                    .ThenInclude(s => s.StudentProfile)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }
    }
}
