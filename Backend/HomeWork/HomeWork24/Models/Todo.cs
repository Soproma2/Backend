using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork24.Models
{
    internal class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompeted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
