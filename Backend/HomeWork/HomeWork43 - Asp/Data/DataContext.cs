using HomeWork43___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork43___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> books {  get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
