using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class MovieGenre
    {
        public int Id { get; set; }
        public bool IsPrimary { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
