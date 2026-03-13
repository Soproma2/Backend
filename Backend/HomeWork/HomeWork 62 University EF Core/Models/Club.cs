using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Models
{
    internal class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MeetingSchedule { get; set; }

        // MANY-TO-MANY ნავიგაცია
        public ICollection<StudentClub> StudentClubs { get; set; } = new List<StudentClub>();
    }
}
