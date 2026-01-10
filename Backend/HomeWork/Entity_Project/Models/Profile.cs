using Entity_Project.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Models
{
    internal class Profile : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
