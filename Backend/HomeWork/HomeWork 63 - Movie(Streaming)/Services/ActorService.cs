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
    internal class ActorService
    {

        private readonly StreamingDbContext _context;

        public ActorService(StreamingDbContext context) => _context = context;

        public async Task<Actor> CreateActorAsync(
            string fullName, DateTime dateOfBirth, string nationality)
        {
            var actor = new Actor
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Nationality = nationality
            };
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            return await _context.Actors
                .Include(a => a.MovieCasts).ThenInclude(mc => mc.Movie)
                .ToListAsync();
        }
    }
}
