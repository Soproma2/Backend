using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne1.Models
{
    internal class UserProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }

        public int UserId { get; set; }
    }
}
