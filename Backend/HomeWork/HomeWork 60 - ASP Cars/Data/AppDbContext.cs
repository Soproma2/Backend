using HomeWork_60___ASP_Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_60___ASP_Cars.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Buyer)
                .WithMany()
                .HasForeignKey(p => p.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Car)
                .WithMany()
                .HasForeignKey(p => p.CarId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
