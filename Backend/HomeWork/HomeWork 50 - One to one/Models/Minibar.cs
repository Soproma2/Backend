using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class Minibar
    {
        public int Id { get; set; }
        public DateTime LastRefillDate { get; set; } = DateTime.Now;
        public decimal CurrentValue { get; set; } = 0;

        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
