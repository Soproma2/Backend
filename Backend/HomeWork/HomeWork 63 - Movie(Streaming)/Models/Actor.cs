using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}
