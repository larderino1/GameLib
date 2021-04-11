using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Front.Services.ModeServices
{
    public interface IModeServices
    {
        Task<IEnumerable<Mode>> GetModeListAsync();

        Task<Mode> GetModeByIdAsync(Guid id);

        Task<bool> UpdateModeAsync(Guid id, Mode mode);

        Task<bool> CreateModeAsync(Mode mode);

        Task<bool> DeleteModeAsync(Guid id);
    }
}
