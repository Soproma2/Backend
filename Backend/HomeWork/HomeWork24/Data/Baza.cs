using HomeWork24.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork24.Data
{
    internal class Baza : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;
                  Initial Catalog=ToDoDB;
                  Integrated Security=True;
                  Connect Timeout=30;
                  TrustServerCertificate=True;
                  Encrypt=False");
        }
    }
}
