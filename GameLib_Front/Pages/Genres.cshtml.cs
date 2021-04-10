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
    public class GenresModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<Genre> Genres { get; set; }

        private readonly IGenreServices _genreService;

        public GenresModel(IGenreServices genreService)
        {
            _genreService = genreService;
        }

        public async Task OnGet()
        {
            Genres = await _genreService.GetGenreListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                Genres = Genres.Where(s => s.Name.Contains(SearchString));
            }
        }
    }
}