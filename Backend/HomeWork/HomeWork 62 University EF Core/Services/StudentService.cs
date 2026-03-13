using HomeWork_62_University_EF_Core.Data;
using HomeWork_62_University_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_62_University_EF_Core.Enums;

namespace HomeWork_62_University_EF_Core.Services
{
    internal class StudentService
    {
        private readonly UniversityDbContext _context;

        public StudentService(UniversityDbContext context)
        {
            _context = context;
        }

        // სტუდენტის დამატება პროფილთან ერთად (One-to-One)
        public async Task<Student> CreateStudentAsync(
            string studentCode, string email, int enrollmentYear,
            string fullName, DateTime dateOfBirth, string address,
            string phoneNumber, string idNumber)
        {
            var student = new Student
            {
                StudentCode = studentCode,
                Email = email,
                EnrollmentYear = enrollmentYear,
                StudentProfile = new StudentProfile
                {
                    FullName = fullName,
                    DateOfBirth = dateOfBirth,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    IDNumber = idNumber
                }
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // ყველა სტუდენტის წამოღება პროფილით
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.StudentProfile)
                .ToListAsync();
        }

        // სტუდენტის პოვნა ID-ით (ყველა კავშირით)
        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students
                .Include(s => s.StudentProfile)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .Include(s => s.StudentClubs)
                    .ThenInclude(sc => sc.Club)
                .Include(s => s.StudentScholarships)
                    .ThenInclude(ss => ss.Scholarship)
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        // სტუდენტის კურსზე ჩარიცხვა (Many-to-Many)
        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            var alreadyEnrolled = await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (alreadyEnrolled)
                throw new InvalidOperationException("სტუდენტი უკვე ჩარიცხულია ამ კურსზე.");

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.Now,
                Status = Status.Active,
                Grade = null
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        // ნიშნის დაყენება
        public async Task SetGradeAsync(int studentId, int courseId, double grade)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment == null)
                throw new InvalidOperationException("ჩარიცხვა ვერ მოიძებნა.");

            enrollment.Grade = grade;
            enrollment.Status = grade >= 51 ? Status.Completed : Status.Failed;
            await _context.SaveChangesAsync();
        }

        // სტუდენტის კლუბში დამატება (Many-to-Many)
        public async Task JoinClubAsync(int studentId, int clubId, Position position = Position.Member)
        {
            var studentClub = new StudentClub
            {
                StudentId = studentId,
                ClubId = clubId,
                JoinedDate = DateTime.Now,
                Position = position
            };

            _context.StudentClubs.Add(studentClub);
            await _context.SaveChangesAsync();
        }

        // სტიპენდიის მინიჭება (Many-to-Many)
        public async Task AwardScholarshipAsync(int studentId, int scholarshipId,
            DateTime awardedDate, DateTime expiryDate)
        {
            var ss = new StudentScholarship
            {
                StudentId = studentId,
                ScholarshipId = scholarshipId,
                AwardedDate = awardedDate,
                ExpiryDate = expiryDate,
                IsActive = true
            };

            _context.StudentScholarships.Add(ss);
            await _context.SaveChangesAsync();
        }

        // სტუდენტის წაშლა
        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
                throw new InvalidOperationException("სტუდენტი ვერ მოიძებნა.");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
