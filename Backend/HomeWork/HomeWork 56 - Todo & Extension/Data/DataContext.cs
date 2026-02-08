using HomeWork_56___Todo___Extension.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_56___Todo___Extension.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Todo> todos { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}
