using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class RoomKey
    {
        public int Id { get; set; }
        public string KeyCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime IssuedDate { get; set; } = DateTime.Now;

        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
