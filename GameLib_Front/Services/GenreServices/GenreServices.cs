using DbManager.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameLib_Front.Services.GenreServices
{
    public class GenreServices : IGenreServices
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseAdress;

        public GenreServices(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();

            _baseAdress = configuration.GetConnectionString("GameLibServerUri");
        }

        public async Task<bool> CreateGenreAsync(Genre genre)
        {
            var genreJson = JsonConvert.SerializeObject(genre);

            var response = await _httpClient.PostAsync(
                $"{_baseAdress}/genres",
                new StringContent(genreJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGenreAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseAdress}/genres/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/genres/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Genre>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<Genre>> GetGenreListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/genres");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Genre>>(await response.Content.ReadAsStringAsync());
            }

            return Enumerable.Empty<Genre>();
        }

        public async Task<bool> UpdateGenreAsync(Guid id, Genre genre)
        {
            var genreJson = JsonConvert.SerializeObject(genre);

            var response = await _httpClient.PutAsync(
                $"{_baseAdress}/genres/id",
                new StringContent(genreJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
