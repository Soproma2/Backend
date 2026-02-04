using HomeWork_53___Social_System.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_53___Social_System.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; } 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
