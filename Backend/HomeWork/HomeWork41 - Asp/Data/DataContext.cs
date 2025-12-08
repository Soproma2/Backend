using HomeWork41___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork41___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
