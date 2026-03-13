using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_62_University_EF_Core.Enums;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class StudentClub
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClubId { get; set; }
        public Club Club { get; set; }

        public DateTime JoinedDate { get; set; }
        public Position Position { get; set; } 
    }
}
