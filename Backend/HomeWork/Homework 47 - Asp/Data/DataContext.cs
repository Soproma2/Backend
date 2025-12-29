using Homework_47___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_47___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
