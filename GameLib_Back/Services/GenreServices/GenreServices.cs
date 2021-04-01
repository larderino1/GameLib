using DbManager.Data;
using DbManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.GenreServices
{
    public class GenreServices : IGenreServices
    {
        private readonly ApplicationDbContext _context;

        public GenreServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> CreateGenreAsync(Genre genre)
        {
            try
            {
                await _context.Genres.AddAsync(genre);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Mode can`t be null", ex.InnerException);
            }

            return genre;
        }

        public async Task<Genre> DeleteGenreAsync(Guid id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return genre;
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>> GetGenreListAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task UpdateGenreAsync(Guid id, Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                _context.Genres.Update(genre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GenreExists(id))
                {
                    throw new ArgumentNullException("Genre not found", ex);
                }
                else
                    throw ex;
            }
        }

        private bool GenreExists(Guid id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
