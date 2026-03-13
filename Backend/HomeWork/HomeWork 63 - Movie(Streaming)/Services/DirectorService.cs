using HomeWork_63___Movie_Streaming_.Data;
using HomeWork_63___Movie_Streaming_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Services
{
    internal class DirectorService
    {
        private readonly StreamingDbContext _context;

        public DirectorService(StreamingDbContext context) => _context = context;

        public async Task<Director> CreateDirectorAsync(
            string fullName, string nationality, DateTime dateOfBirth)
        {
            var director = new Director
            {
                FullName = fullName,
                Nationality = nationality,
                DateOfBirth = dateOfBirth
            };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<List<Director>> GetAllDirectorsAsync()
        {
            return await _context.Directors
                .Include(d => d.MovieDirectors).ThenInclude(md => md.Movie)
                .ToListAsync();
        }
    }
}
