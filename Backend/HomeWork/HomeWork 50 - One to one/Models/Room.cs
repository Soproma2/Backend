using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; } = true;

        public RoomKey RoomKey { get; set; }
        public Minibar Minibar { get; set; }
    }
}
