using HomeWork_57___Asp_E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_57___Asp_E_Commerce.Data
{
    public class Datacontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {
        }
    }
}
