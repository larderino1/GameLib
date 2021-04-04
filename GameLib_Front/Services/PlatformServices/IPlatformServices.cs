using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Services.PlatformServices
{
    public interface IPlatformServices
    {
        Task<IEnumerable<Platform>> GetPlatformsListAsync();

        Task<Platform> GetPlatformByIdAsync(Guid id);

        Task<bool> UpdatePlatformAsync(Guid id, Platform platform);

        Task<bool> CreatePlatformAsync(Platform platform);

        Task<bool> DeletePlatformAsync(Guid id);
    }
}
