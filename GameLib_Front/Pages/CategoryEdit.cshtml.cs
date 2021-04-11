using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class CategoryEditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ICategoryServices _categoryService;

        public CategoryEditModel(ICategoryServices categoryService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Category.Id = id;
                await _categoryService.UpdateCategoryAsync(id, Category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Categories");
        }
    }
}
