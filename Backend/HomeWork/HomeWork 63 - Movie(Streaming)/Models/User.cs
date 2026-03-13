using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }

        public ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
