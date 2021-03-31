using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.PlatformServices
{
    public interface IPlatformServices
    {
        Task<IEnumerable<Platform>> GetPlatformsListAsync();

        Task<Platform> GetPlatformByIdAsync(Guid id);

        Task UpdatePlatformAsync(Guid id, Platform platform);

        Task CreatePlatformAsync(Platform platform);

        Task DeletePlatformAsync(Guid id);
    }
}
