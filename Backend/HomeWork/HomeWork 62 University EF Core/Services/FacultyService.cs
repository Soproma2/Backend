using HomeWork_62_University_EF_Core.Data;
using HomeWork_62_University_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_62_University_EF_Core.Services
{
    internal class FacultyService
    {
        private readonly UniversityDbContext _context;

        public FacultyService(UniversityDbContext context)
        {
            _context = context;
        }

        // ფაკულტეტის დამატება დეკანთან ერთად (One-to-One)
        public async Task<Faculty> CreateFacultyAsync(
            string name, string building, int establishedYear,
            string deanName, string deanEmail, string officeRoom)
        {
            var faculty = new Faculty
            {
                Name = name,
                Building = building,
                EstablishedYear = establishedYear,
                FacultyDean = new FacultyDean
                {
                    FullName = deanName,
                    Email = deanEmail,
                    OfficeRoom = officeRoom,
                    AppointedDate = DateTime.Now
                }
            };

            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();
            return faculty;
        }

        // ყველა ფაკულტეტი დეკანით და კურსებით
        public async Task<List<Faculty>> GetAllFacultiesAsync()
        {
            return await _context.Faculties
                .Include(f => f.FacultyDean)
                .Include(f => f.Courses)
                .ToListAsync();
        }
    }
}
