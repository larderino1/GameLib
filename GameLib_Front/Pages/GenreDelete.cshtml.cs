using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.GenreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class GenreDeleteModel : PageModel
    {
        [BindProperty]
        public Genre Genre { get; set; }

        private readonly IGenreServices _genreService;

        public GenreDeleteModel(IGenreServices genreService)
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

            if(Genre == null)
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

            await _genreService.DeleteGenreAsync(id);

            return RedirectToPage("./Genres");
        }
    }
}
