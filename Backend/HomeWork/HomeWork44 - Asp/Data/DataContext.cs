using HomeWork44___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork44___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
