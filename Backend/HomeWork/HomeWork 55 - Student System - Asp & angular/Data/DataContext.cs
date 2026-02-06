using HomeWork_55___Student_System___Asp___angular.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork_55___Student_System___Asp___angular.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
