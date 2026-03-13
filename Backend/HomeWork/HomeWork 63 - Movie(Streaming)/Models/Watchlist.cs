using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class Watchlist
    {
        public int Id { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsWatched { get; set; }
        public int? UserRating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
