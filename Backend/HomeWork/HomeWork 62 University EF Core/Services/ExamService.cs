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
    internal class ExamService
    {
        private readonly UniversityDbContext _context;

        public ExamService(UniversityDbContext context)
        {
            _context = context;
        }

        // გამოცდის შექმნა შედეგთან ერთად (One-to-One)
        public async Task<Exam> CreateExamWithResultAsync(
            string subject, DateTime examDate, ExamType examType, string room,
            int totalParticipants, double averageScore,
            double highestScore, double lowestScore,
            int passCount, int failCount)
        {
            var exam = new Exam
            {
                Subject = subject,
                ExamDate = examDate,
                ExamType = examType,
                Room = room,
                ExamResult = new ExamResult
                {
                    TotalParticipants = totalParticipants,
                    AverageScore = averageScore,
                    HighestScore = highestScore,
                    LowestScore = lowestScore,
                    PassCount = passCount,
                    FailCount = failCount
                }
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        // ყველა გამოცდა შედეგებით
        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _context.Exams
                .Include(e => e.ExamResult)
                .OrderBy(e => e.ExamDate)
                .ToListAsync();
        }
    }
}
