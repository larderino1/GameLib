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
    public class CategoryDeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        public readonly ICategoryServices _categoryService;

        public CategoryDeleteModel(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            Category = await _categoryService.GetCategoryByIdAsync(id);

            if(Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToPage("./Categories");
        }
    }
}
