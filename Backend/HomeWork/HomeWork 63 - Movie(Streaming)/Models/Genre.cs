using HomeWork_63___Movie_Streaming_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class Genre
    {
        public int Id { get; set; }
        public GenreE Name { get; set; }
        public string Description { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
