using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    public class CategoriesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<Category> Categories { get; set; }

        private readonly ICategoryServices _categoryService;

        public CategoriesModel(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task OnGet()
        {
            Categories = await _categoryService.GetCategoryListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                Categories = Categories.Where(s => s.Name.Contains(SearchString));
            }
        }
    }
}
