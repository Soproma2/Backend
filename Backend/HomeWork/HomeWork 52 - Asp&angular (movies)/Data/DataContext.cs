using HomeWork_52___Asp_angular__movies_.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_52___Asp_angular__movies_.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
