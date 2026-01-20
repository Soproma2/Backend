using Microsoft.EntityFrameworkCore;

namespace HomeWork_51___Asp_JWT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
