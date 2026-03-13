using HomeWork_62_University_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Data
{
    internal class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorProfile> ProfessorProfiles { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FacultyDean> FacultyDeans { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<StudentClub> StudentClubs { get; set; }
        public DbSet<Textbook> Textbooks { get; set; }
        public DbSet<CourseTextbook> CourseTextbooks { get; set; }
        public DbSet<Scholarship> Scholarships { get; set; }
        public DbSet<StudentScholarship> StudentScholarships { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
    }
}
