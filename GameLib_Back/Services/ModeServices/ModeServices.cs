using DbManager.Data;
using DbManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.ModeServices
{
    public class ModeServices : IModeServices
    {

        private readonly ApplicationDbContext _context;

        public ModeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Mode> CreateModeAsync(Mode mode)
        {
            try
            {
                await _context.Modes.AddAsync(mode);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Mode can`t be null", ex.InnerException);
            }

            return mode;
        }

        public async Task<Mode> DeleteModeAsync(Guid id)
        {
            var mode = await _context.Modes.FindAsync(id);

            if (mode == null)
            {
                return mode;
            }

            _context.Modes.Remove(mode);
            await _context.SaveChangesAsync();

            return mode;
        }

        public async Task<Mode> GetModeByIdAsync(Guid id)
        {
            return await _context.Modes.FindAsync(id);
        }

        public async Task<IEnumerable<Mode>> GetModeListAsync()
        {
            return await _context.Modes.ToListAsync();
        }

        public async Task UpdateModeAsync(Guid id, Mode mode)
        {
            _context.Entry(mode).State = EntityState.Modified;

            try
            {
                _context.Modes.Update(mode);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ModeExists(id))
                {
                    throw new ArgumentNullException("Mode not found", ex);
                }
                else
                    throw ex;
            }
        }

        private bool ModeExists(Guid id)
        {
            return _context.Modes.Any(e => e.Id == id);
        }
    }
}
