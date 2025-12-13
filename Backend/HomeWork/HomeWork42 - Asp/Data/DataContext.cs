using HomeWork42___Asp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork42___Asp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
