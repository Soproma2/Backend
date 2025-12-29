using HomeWork_48___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_48___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
