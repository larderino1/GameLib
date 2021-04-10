using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Services.GenreServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    public class GenreEditModel : PageModel
    {
        [BindProperty]
        public Genre Genre { get; set; }

        private readonly IGenreServices _genreService;

        public GameEditModel(IGenreServices genreService)
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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _genreService.UpdateGenreAsync(Genre.Id, Genre);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Genres");
        }
    }
}
