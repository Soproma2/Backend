using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_62_University_EF_Core.Enums;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Exam
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime ExamDate { get; set; }
        public ExamType ExamType { get; set; }
        public string Room { get; set; }

        // ONE-TO-ONE
        public ExamResult ExamResult { get; set; }
    }
}
