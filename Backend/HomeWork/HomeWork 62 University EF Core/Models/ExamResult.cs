using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class ExamResult
    {
        public int Id { get; set; }
        public int TotalParticipants { get; set; }
        public double AverageScore { get; set; }
        public double HighestScore { get; set; }
        public double LowestScore { get; set; }
        public int PassCount { get; set; }
        public int FailCount { get; set; }

        // Foreign Key → Exam
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
