using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLib_Front.Services.CategoryServices
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategoryListAsync();

        Task<Category> GetCategoryByIdAsync(Guid id);

        Task<bool> UpdateCategoryAsync(Guid id, Category category);

        Task<bool> CreateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(Guid id);
    }
}
