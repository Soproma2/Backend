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
    internal class MovieService
    {
        private readonly StreamingDbContext _context;

        public MovieService(StreamingDbContext context) => _context = context;

        // ფილმის დამატება
        public async Task<Movie> CreateMovieAsync(
            string title, int releaseYear, int durationMinutes, string language, decimal rating)
        {
            var movie = new Movie
            {
                Title = title,
                ReleaseYear = releaseYear,
                DurationMinutes = durationMinutes,
                Language = language,
                Rating = rating
            };
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        // ყველა ფილმი
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Actor)
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Include(m => m.MovieDirectors).ThenInclude(md => md.Director)
                .ToListAsync();
        }

        // მსახიობის დამატება ფილმში (Many-to-Many #1)
        public async Task AddActorToMovieAsync(int movieId, int actorId, string characterName, CastType castType)
        {
            var movieExists = await _context.Movies.AnyAsync(m => m.Id == movieId);
            if (!movieExists) throw new ArgumentException($"ფილმი ID-ით {movieId} ვერ მოიძებნა.");

            var actorExists = await _context.Actors.AnyAsync(a => a.Id == actorId);
            if (!actorExists) throw new ArgumentException($"მსახიობი ID-ით {actorId} ვერ მოიძებნა.");

            _context.MovieCasts.Add(new MovieCast
            {
                MovieId = movieId,
                ActorId = actorId,
                CharacterName = characterName,
                CastType = castType
            });
            await _context.SaveChangesAsync();
        }

        // ჟანრის მიბმა ფილმზე (Many-to-Many #2)
        public async Task AddGenreToMovieAsync(int movieId, int genreId, bool isPrimary)
        {
            var movieExists = await _context.Movies.AnyAsync(m => m.Id == movieId);
            if (!movieExists) throw new ArgumentException($"ფილმი ID-ით {movieId} ვერ მოიძებნა.");

            var genreExists = await _context.Genres.AnyAsync(g => g.Id == genreId);
            if (!genreExists) throw new ArgumentException($"ჟანრი ID-ით {genreId} ვერ მოიძებნა.");

            _context.MovieGenres.Add(new MovieGenre
            {
                MovieId = movieId,
                GenreId = genreId,
                IsPrimary = isPrimary
            });
            await _context.SaveChangesAsync();
        }

        // რეჟისორის მიბმა ფილმზე (Many-to-Many #4)
        public async Task AddDirectorToMovieAsync(int movieId, int directorId, DirectorRole directorRole)
        {
            var movieExists = await _context.Movies.AnyAsync(m => m.Id == movieId);
            if (!movieExists) throw new ArgumentException($"ფილმი ID-ით {movieId} ვერ მოიძებნა.");

            var directorExists = await _context.Directors.AnyAsync(d => d.Id == directorId);
            if (!directorExists) throw new ArgumentException($"რეჟისორი ID-ით {directorId} ვერ მოიძებნა.");

            _context.MovieDirectors.Add(new MovieDirector
            {
                MovieId = movieId,
                DirectorId = directorId,
                DirectorRole = directorRole
            });
            await _context.SaveChangesAsync();
        }
    }
}
