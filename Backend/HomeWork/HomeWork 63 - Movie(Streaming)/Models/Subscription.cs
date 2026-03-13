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
    internal class Subscription
    {
        public int Id { get; set; }
        public SubscriptionPlan Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyPrice { get; set; }

        public int MaxScreens { get; set; }
        public bool Has4K { get; set; }

        public ICollection<UserSubscription> UserSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
