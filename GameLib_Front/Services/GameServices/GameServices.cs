using DbManager.Models;
using GameLib_Front.Services.CategoryServices;
using GameLib_Front.Services.GenreServices;
using GameLib_Front.Services.ModeServices;
using GameLib_Front.Services.PlatformServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameLib_Front.Services.GameServices
{
    public class GameServices : IGameServices
    {
        private readonly HttpClient _httpClient;

        private readonly IGenreServices _genreService;

        private readonly IModeServices _modeService;

        private readonly IPlatformServices _platformService;

        private readonly ICategoryServices _categoryService;

        private readonly string _baseAdress;

        public GameServices(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IGenreServices genreService,
            IModeServices modeService,
            IPlatformServices platformService,
            ICategoryServices categoryService)
        {
            _genreService = genreService;
            _modeService = modeService;
            _platformService = platformService;
            _categoryService = categoryService;

            _httpClient = httpClientFactory.CreateClient();

            _baseAdress = configuration.GetConnectionString("GameLibServerUri");
        }

        public async Task<bool> CreateGameAsync(Game game)
        {
            var gameJson = JsonConvert.SerializeObject(game);

            var response = await _httpClient.PostAsync(
                $"{_baseAdress}/games",
                new StringContent(gameJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGameAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseAdress}/games/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Game> GetGameByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/games/{id}");

            if (response.IsSuccessStatusCode)
            {
                var game = JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());

                game.Genre = await _genreService.GetGenreByIdAsync(game.GenreId);
                game.Mode = await _modeService.GetModeByIdAsync(game.ModeId);
                game.Platform = await _platformService.GetPlatformByIdAsync(game.PlatformId);
                game.Category = await _categoryService.GetCategoryByIdAsync(game.CategoryId);
            }

            return null;
        }

        public async Task<IEnumerable<Game>> GetGameListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/games");

            if (response.IsSuccessStatusCode)
            {
                var games = JsonConvert.DeserializeObject<IEnumerable<Game>>(await response.Content.ReadAsStringAsync());

                foreach(var game in games)
                {
                    game.Genre = await _genreService.GetGenreByIdAsync(game.GenreId);
                    game.Mode = await _modeService.GetModeByIdAsync(game.ModeId);
                    game.Platform = await _platformService.GetPlatformByIdAsync(game.PlatformId);
                    game.Category = await _categoryService.GetCategoryByIdAsync(game.CategoryId);
                }

                return games;
            }

            return Enumerable.Empty<Game>();
        }

        public async Task<bool> UpdateGameAsync(Guid id, Game game)
        {
            var gameJson = JsonConvert.SerializeObject(game);

            var response = await _httpClient.PutAsync(
                $"{_baseAdress}/games/{id}",
                new StringContent(gameJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
