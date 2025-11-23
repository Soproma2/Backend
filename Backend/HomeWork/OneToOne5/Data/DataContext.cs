using Microsoft.EntityFrameworkCore;
using OneToOne5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne5.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarServiceBook> ServiceBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
    }
}
