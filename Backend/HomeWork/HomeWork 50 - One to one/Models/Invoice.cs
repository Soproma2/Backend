using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_50___One_to_one.Models
{
    internal class Invoice
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentDate { get; set; }
        public DateTime GeneratedDate { get; set; } = DateTime.Now;

        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}
