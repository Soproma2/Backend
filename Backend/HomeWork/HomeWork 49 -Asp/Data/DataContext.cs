using HomeWork_49__Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_49__Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
