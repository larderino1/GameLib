using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Front.Services.GameServices
{
    public interface IGameServices
    {
        Task<IEnumerable<Game>> GetGameListAsync();

        Task<Game> GetGameByIdAsync(Guid id);

        Task<bool> UpdateGameAsync(Guid id, Game game);

        Task<bool> CreateGameAsync(Game game);

        Task<bool> DeleteGameAsync(Guid id);
    }
}
