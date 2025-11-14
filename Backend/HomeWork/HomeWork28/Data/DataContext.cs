using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork28.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork28.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Director> directors { get; set; }
        public DbSet<Company> companies { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudPass;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
    }
}
