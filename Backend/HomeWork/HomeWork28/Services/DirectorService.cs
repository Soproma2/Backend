using HomeWork28.Data;
using HomeWork28.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28.Services
{
    internal class DirectorService
    {
        DataContext _db = new DataContext();
        public void RegisterDir()
        {
            Console.WriteLine("Enter FirstName: ");
            string FN = Console.ReadLine();

            Console.WriteLine("Enter LastName: ");
            string LN = Console.ReadLine();

            Console.WriteLine("Enter Your company name: ");
            string CN = Console.ReadLine();

            Director director = new Director()
            {
                FirstName = FN,
                LastName = LN,
                Company = new Company()
                {
                    Title = CN
                }
            };

            _db.directors.Add(director);
            _db.SaveChanges();
            Console.WriteLine("Director registred successfully.");
        }

        public void ShowDir()
        {
            Console.WriteLine("Enter Direcotr Id: ");
            int Id = int.Parse(Console.ReadLine());

            var dir = _db.directors
                .Include(d => d.Company)
                .FirstOrDefault(d => d.Id == Id);

            if (dir != null)
            {
                Console.WriteLine($"Director: {dir.FirstName} {dir.LastName}, Company: {dir.Company.Title}");
            }
            else
            {
                Console.WriteLine("Director not found.");
            }
        }
    }
}
