using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_63___Movie_Streaming_.Enums;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class MovieDirector
    {
        public int Id { get; set; }
        public DirectorRole DirectorRole { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
