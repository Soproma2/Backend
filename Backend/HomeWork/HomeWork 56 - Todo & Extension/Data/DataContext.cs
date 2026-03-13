using HomeWork_56___Todo___Extension.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_56___Todo___Extension.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> Todos { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
