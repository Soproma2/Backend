using Microsoft.EntityFrameworkCore;
using OneToOne2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne2.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCard> StudentCards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
    }
}
