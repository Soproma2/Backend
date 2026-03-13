using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public string Language { get; set; }

        [Column(TypeName = "decimal(4,1)")]
        public decimal Rating { get; set; }

        // Many-to-Many ნავიგაციები
        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
        public ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();
    }
}
