using DbManager.Data;
using DbManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.GameServices
{
    public class GameServices : IGameServices
    {
        private readonly ApplicationDbContext _context;

        public GameServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateGameAsync(Game game)
        {
            try
            {
                await _context.Games.AddAsync(game);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Game can`t be null", ex.InnerException);
            }

            return game;
        }

        public async Task<Game> DeleteGameAsync(Guid id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return game;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<Game> GetGameByIdAsync(Guid id)
        {
            return await _context.Games
                .AsNoTracking()
                .Include(a => a.Category)
                .Include(a => a.Platform)
                .Include(a => a.Mode)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Game>> GetGameListAsync()
        {
            return await _context.Games
                .AsNoTracking()
                .Include(a => a.Category)
                .Include(a => a.Platform)
                .Include(a => a.Mode)
                .Include(a => a.Genre)
                .ToListAsync();
        }

        public async Task UpdateGameAsync(Guid id, Game game)
        {
            _context.Entry(game).State = EntityState.Modified;

            try
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GameExists(id))
                {
                    throw new ArgumentNullException("Game not found", ex);
                }
                else
                    throw ex;
            }
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
