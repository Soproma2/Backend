using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class LoyaltyCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int Points { get; set; } = 0;
        public DateTime MemberSince { get; set; } = DateTime.Now;

        public Guest Guest { get; set; }
        public int GuestId { get; set; }
    }
}
