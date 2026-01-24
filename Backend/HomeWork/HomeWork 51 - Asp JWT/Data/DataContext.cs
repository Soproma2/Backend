using HomeWork_51___Asp_JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_51___Asp_JWT.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
