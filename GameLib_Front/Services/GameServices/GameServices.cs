using DbManager.Models;
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

        private readonly string _baseAdress;

        public GameServices(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
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
                return JsonConvert.DeserializeObject<Game>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<Game>> GetGameListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/games");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Game>>(await response.Content.ReadAsStringAsync());
            }

            return Enumerable.Empty<Game>();
        }

        public async Task<bool> UpdateGameAsync(Guid id, Game game)
        {
            var gameJson = JsonConvert.SerializeObject(game);

            var response = await _httpClient.PutAsync(
                $"{_baseAdress}/games/id",
                new StringContent(gameJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
