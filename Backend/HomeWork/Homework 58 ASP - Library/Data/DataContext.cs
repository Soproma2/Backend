using Homework_58_ASP___Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_58_ASP___Library.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
