using HomeWork_63___Movie_Streaming_.Data;
using HomeWork_63___Movie_Streaming_.Enums;
using HomeWork_63___Movie_Streaming_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_63___Movie_Streaming_.Services
{
    internal class GenreService
    {
        private readonly StreamingDbContext _context;

        public GenreService(StreamingDbContext context) => _context = context;

        public async Task<Genre> CreateGenreAsync(GenreE name, string description)
        {
            var genre = new Genre { Name = name, Description = description };
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}
