using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.GenreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class GenreEditModel : PageModel
    {
        [BindProperty]
        public Genre Genre { get; set; }

        private readonly IGenreServices _genreService;

        public GenreEditModel(IGenreServices genreService)
        {
            _genreService = genreService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Genre = await _genreService.GetGenreByIdAsync(id);

            if (Genre == null)
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
                Genre.Id = id;
                await _genreService.UpdateGenreAsync(id, Genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Genres");
        }
    }
}
