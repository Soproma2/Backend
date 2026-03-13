using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class Director
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();
    }
}
