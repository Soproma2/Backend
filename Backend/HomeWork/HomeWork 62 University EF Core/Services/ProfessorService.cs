using HomeWork_62_University_EF_Core.Data;
using HomeWork_62_University_EF_Core.Enums;
using HomeWork_62_University_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Services
{
    internal class ProfessorService
    {
        private readonly UniversityDbContext _context;

        public ProfessorService(UniversityDbContext context)
        {
            _context = context;
        }

        // პროფესორის დამატება პროფილთან ერთად (One-to-One)
        public async Task<Professor> CreateProfessorAsync(
            string email, AcademicRank academicRank,
            string fullName, string specialization,
            int yearsOfExperience, string phoneNumber, decimal salary)
        {
            var professor = new Professor
            {
                Email = email,
                AcademicRank = academicRank,
                ProfessorProfile = new ProfessorProfile
                {
                    FullName = fullName,
                    Specialization = specialization,
                    YearsOfExperience = yearsOfExperience,
                    PhoneNumber = phoneNumber,
                    Salary = salary
                }
            };

            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        // ყველა პროფესორი პროფილით
        public async Task<List<Professor>> GetAllProfessorsAsync()
        {
            return await _context.Professors
                .Include(p => p.ProfessorProfile)
                .Include(p => p.CourseTeachers)
                    .ThenInclude(ct => ct.Course)
                .ToListAsync();
        }

        // პროფესორის კურსზე მინიჭება (Many-to-Many)
        public async Task AssignToCourseAsync(int professorId, int courseId, Role role)
        {
            var ct = new CourseTeacher
            {
                ProfessorId = professorId,
                CourseId = courseId,
                Role = role,
                AssignedFrom = DateTime.Now
            };

            _context.CourseTeachers.Add(ct);
            await _context.SaveChangesAsync();
        }
    }
}
