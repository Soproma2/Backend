using Entity_Project.Core;
using Entity_Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Project.Models
{
    internal class Order : BaseEntity
    {
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
