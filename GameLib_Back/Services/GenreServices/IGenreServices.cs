using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.GenreServices
{
    public interface IGenreServices
    {
        Task<IEnumerable<Genre>> GetGenreListAsync();

        Task<Genre> GetGenreByIdAsync(Guid id);

        Task UpdateGenreAsync(Guid id, Genre genre);

        Task CreateGenreAsync(Genre genre);

        Task DeleteGenreAsync(Guid id);
    }
}
