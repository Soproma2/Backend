using HomeWork_46___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_46___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> books { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
