using HomeWork_64_Asp___Todo.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_64_Asp___Todo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
