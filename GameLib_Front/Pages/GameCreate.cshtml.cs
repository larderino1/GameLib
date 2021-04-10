using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DbManager.Models;
using GameLib_Front.Data.Models;
using GameLib_Front.Services.CategoryServices;
using GameLib_Front.Services.GameServices;
using GameLib_Front.Services.GenreServices;
using GameLib_Front.Services.ModeServices;
using GameLib_Front.Services.PlatformServices;
using GameLib_Front.Services.StorageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameLib_Front.Pages
{
    public class GameCreateModel : PageModel
    {
        [BindProperty]
        public BufferedSingleFile FileManager { get; set; }

        [BindProperty]
        public Game Game { get; set; }

        private readonly IGameServices _gameService;

        private readonly IStorageService _storageService;

        private readonly ICategoryServices _categoryService;

        private readonly IGenreServices _genreService;

        private readonly IModeServices _modeService;

        private readonly IPlatformServices _platformService;

        public GameCreateModel(
            IGameServices gameService,
            IStorageService storageService,
            ICategoryServices categoryService,
            IGenreServices genreService,
            IModeServices modeService,
            IPlatformServices platformService)
        {
            _gameService = gameService;
            _storageService = storageService;
            _categoryService = categoryService;
            _genreService = genreService;
            _modeService = modeService;
            _platformService = platformService;
        }

        public async Task<IActionResult> OnGet()
        {
            var categories = await _categoryService.GetCategoryListAsync();

            ViewData["CategoryName"] = new SelectList(categories, "Id", "Name");

            var genres = await _genreService.GetGenreListAsync();

            ViewData["GenreName"] = new SelectList(genres, "Id", "Name");

            var modes = await _modeService.GetModeListAsync();

            ViewData["ModeName"] = new SelectList(modes, "Id", "Name");

            var platforms = await _platformService.GetPlatformsListAsync();

            ViewData["PlatformName"] = new SelectList(platforms, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Game.PhotoUrl = await _storageService.UploadPhoto(FileManager.FormFile);

            await _gameService.CreateGameAsync(Game);

            return RedirectToPage("./Games");
        }
    }
}
