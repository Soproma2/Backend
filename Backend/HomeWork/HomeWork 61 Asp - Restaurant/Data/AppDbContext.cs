using HomeWork_61_Asp___Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_61_Asp___Restaurant.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .Property(f => f.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Food)
                .WithMany()
                .HasForeignKey(i => i.FoodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
