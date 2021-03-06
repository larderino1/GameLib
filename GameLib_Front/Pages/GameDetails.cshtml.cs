using DbManager.Models;
using GameLib_Front.Services.GameServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace GameLib_Front.Pages
{
    public class GameDetailsModel : PageModel
    {
        [BindProperty]
        public Game Game { get; set; }

        private readonly IGameServices _gameService;

        public GameDetailsModel(IGameServices gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Game = await _gameService.GetGameByIdAsync(id);

            if (Game == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
