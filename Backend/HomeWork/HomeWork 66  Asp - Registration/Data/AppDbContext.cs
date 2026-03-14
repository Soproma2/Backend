using HomeWork_66__Asp___Registration.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_66__Asp___Registration.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
