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
    public class CategoryCreateModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ICategoryServices _categoryService;

        public CategoryCreateModel(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _categoryService.CreateCategoryAsync(Category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Categories");
        }
    }
}
