using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Constants;
using GameLib_Front.Services.GameServices;
using GameLib_Front.Services.StorageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLib_Front.Pages
{
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class GameDeleteModel : PageModel
    {
        [BindProperty]
        public Game Game { get; set; }

        private readonly IGameServices _gameService;

        private readonly IStorageService _storageService;

        public GameDeleteModel(
            IGameServices gameService,
            IStorageService storageService)
        {
            _gameService = gameService;

            _storageService = storageService;
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

            var game = await _gameService.GetGameByIdAsync(id);

            await _gameService.DeleteGameAsync(id);

            await _storageService.DeleteBlob(game.PhotoUrl);

            return RedirectToPage("./Games");
        }
    }
}
