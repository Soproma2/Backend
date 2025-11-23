using Microsoft.EntityFrameworkCore;
using OneToOne4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne4.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSalaryInfo> EmployeeSalaryInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
    }
}
