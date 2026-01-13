using Microsoft.EntityFrameworkCore;
using SocialMedia___Asp_50.Models;

namespace SocialMedia___Asp_50.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
