using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Back.Services.ModeServices
{
    public interface IModeServices
    {
        Task<IEnumerable<Mode>> GetModeListAsync();

        Task<Mode> GetModeByIdAsync(Guid id);

        Task UpdateModeAsync(Guid id, Mode mode);

        Task<Mode> CreateModeAsync(Mode mode);

        Task<Mode> DeleteModeAsync(Guid id);
    }
}
