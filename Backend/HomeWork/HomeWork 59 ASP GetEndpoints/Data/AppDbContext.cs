using HomeWork_59_ASP_GetEndpoints.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_59_ASP_GetEndpoints.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
