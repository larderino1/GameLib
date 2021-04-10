using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Services.GameServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    public class GamesModel : PageModel
    {
        private readonly IGameServices _gameService;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<Game> Games { get; set; }

        public GamesModel(IGameServices gameService)
        {
            _gameService = gameService;
        }

        public async Task OnGet()
        {
            Games = await _gameService.GetGameListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                Games = Games.Where(
                    s => s.Name.Contains(SearchString)
                    ||
                    s.Mode.Name.Contains(SearchString)
                    ||
                    s.Platform.Name.Contains(SearchString)
                    ||
                    s.Studio.Contains(SearchString)
                    ||
                    s.Genre.Name.Contains(SearchString)
                    ||
                    s.Author.Contains(SearchString)
                    ||
                    s.Category.Name.Contains(SearchString)
                    ||
                    s.Country.Contains(SearchString));
            }
        }
    }
}
