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
    internal class MovieCast
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public CastType CastType { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
