using HomeWork_45___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_45___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
