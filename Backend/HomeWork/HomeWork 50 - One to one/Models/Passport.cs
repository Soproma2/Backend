using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class Passport
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string Country { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Guest Guest { get; set; }
        public int GuestId { get; set; }
    }
}
