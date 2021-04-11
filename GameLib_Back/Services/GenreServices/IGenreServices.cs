using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Back.Services.GenreServices
{
    public interface IGenreServices
    {
        Task<IEnumerable<Genre>> GetGenreListAsync();

        Task<Genre> GetGenreByIdAsync(Guid id);

        Task UpdateGenreAsync(Guid id, Genre genre);

        Task<Genre> CreateGenreAsync(Genre genre);

        Task<Genre> DeleteGenreAsync(Guid id);
    }
}
