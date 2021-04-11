using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Back.Services.GameServices
{
    public interface IGameServices
    {
        Task<IEnumerable<Game>> GetGameListAsync();

        Task<Game> GetGameByIdAsync(Guid id);

        Task UpdateGameAsync(Guid id, Game game);

        Task<Game> CreateGameAsync(Game game);

        Task<Game> DeleteGameAsync(Guid id);
    }
}
