using Microsoft.EntityFrameworkCore;

namespace HomeWork_60___ASP_Cars.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
    }
}
