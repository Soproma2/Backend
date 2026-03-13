using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Models
{
    internal class UserSubscription
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
