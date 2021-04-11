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
    public class GenreCreateModel : PageModel
    {
        [BindProperty]
        public Genre Genre { get; set; }

        private readonly IGenreServices _genreService;

        public GenreCreateModel(IGenreServices genreService)
        {
            _genreService = genreService;
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
                await _genreService.CreateGenreAsync(Genre);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToPage("./Genres");
        }
    }
}
