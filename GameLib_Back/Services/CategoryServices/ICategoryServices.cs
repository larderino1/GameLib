using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLib_Back.Services.CategoryServices
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategoryListAsync();

        Task<Category> GetCategoryByIdAsync(Guid id);

        Task UpdateCategoryAsync(Guid id, Category category);

        Task<Category> CreateCategoryAsync(Category category);

        Task<Category> DeleteCategoryAsync(Guid id);
    }
}
