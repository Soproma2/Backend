using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork34.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork34.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Student> students {  get; set; }
        public DbSet<StudentDetail> studentDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=""Students OTO"";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
    }
}
