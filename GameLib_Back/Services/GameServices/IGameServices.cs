using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.GameServices
{
    public interface IGameServices
    {
        Task<IEnumerable<Game>> GetGameListAsync();

        Task<Game> GetGameByIdAsync(Guid id);

        Task UpdateGameAsync(Guid id, Game game);

        Task CreateGameAsync(Game game);

        Task DeleteGameAsync(Guid id);

        Task<IEnumerable<Game>> GetGamesByCategoryAsync(Guid categoryId);

        Task<IEnumerable<Game>> GetGamesByGenreAsync(Guid genreId);

        Task<IEnumerable<Game>> GetGamesByModeAsync(Guid modeId);

        Task<IEnumerable<Game>> GetGamesByplatformAsync(Guid categoryId);
    }
}
