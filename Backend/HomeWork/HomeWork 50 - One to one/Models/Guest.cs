using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public Passport Passport { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }
    }
}

