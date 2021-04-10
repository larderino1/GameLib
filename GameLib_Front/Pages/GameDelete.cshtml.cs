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
    public class GameDeleteModel : PageModel
    {
        [BindProperty]
        public Game Game { get; set; }

        private readonly IGameServices _gameService;

        public GameDeleteModel(IGameServices gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            Game = await _gameService.GetGameByIdAsync(id);

            if(Game == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            await _gameService.DeleteGameAsync(id);

            return RedirectToPage("./Games");
        }
    }
}
