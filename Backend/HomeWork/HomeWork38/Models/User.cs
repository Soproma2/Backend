using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork38.Core;

namespace HomeWork38.Models
{
    internal class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
