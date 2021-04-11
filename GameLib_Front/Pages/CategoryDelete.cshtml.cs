using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class CategoryDeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ICategoryServices _categoryService;

        public CategoryDeleteModel(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Category = await _categoryService.GetCategoryByIdAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToPage("./Categories");
        }
    }
}
