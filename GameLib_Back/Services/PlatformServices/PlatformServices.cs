using DbManager.Data;
using DbManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.PlatformServices
{
    public class PlatformServices : IPlatformServices
    {

        private readonly ApplicationDbContext _context;

        public PlatformServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Platform> CreatePlatformAsync(Platform platform)
        {
            try
            {
                await _context.Platforms.AddAsync(platform);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Mode can`t be null", ex.InnerException);
            }

            return platform;
        }

        public async Task<Platform> DeletePlatformAsync(Guid id)
        {
            var platform = await _context.Platforms.FindAsync(id);

            if (platform == null)
            {
                return platform;
            }

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return platform;
        }

        public async Task<Platform> GetPlatformByIdAsync(Guid id)
        {
            return await _context.Platforms.FindAsync(id);
        }

        public async Task<IEnumerable<Platform>> GetPlatformsListAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task UpdatePlatformAsync(Guid id, Platform platform)
        {
            _context.Entry(platform).State = EntityState.Modified;

            try
            {
                _context.Platforms.Update(platform);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PlatformExists(id))
                {
                    throw new ArgumentNullException("Platform not found", ex);
                }
                else
                    throw ex;
            }
        }

        private bool PlatformExists(Guid id)
        {
            return _context.Platforms.Any(e => e.Id == id);
        }
    }
}
