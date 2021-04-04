using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Front.Services.GenreServices
{
    public interface IGenreServices
    {
        Task<IEnumerable<Genre>> GetGenreListAsync();

        Task<Genre> GetGenreByIdAsync(Guid id);

        Task<bool> UpdateGenreAsync(Guid id, Genre genre);

        Task<bool> CreateGenreAsync(Genre genre);

        Task<bool> DeleteGenreAsync(Guid id);
    }
}
