using DbManager.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameLib_Front.Services.PlatformServices
{
    public class PlatformServices : IPlatformServices
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseAdress;

        public PlatformServices(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();

            _baseAdress = configuration.GetConnectionString("GameLibServerUri");
        }

        public async Task<bool> CreatePlatformAsync(Platform platform)
        {
            var platformJson = JsonConvert.SerializeObject(platform);

            var response = await _httpClient.PostAsync(
                $"{_baseAdress}/platforms",
                new StringContent(platformJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePlatformAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseAdress}/platforms/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Platform> GetPlatformByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/platforms/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Platform>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<Platform>> GetPlatformsListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/platforms");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Platform>>(await response.Content.ReadAsStringAsync());
            }

            return Enumerable.Empty<Platform>();
        }

        public async Task<bool> UpdatePlatformAsync(Guid id, Platform platform)
        {
            var platformJson = JsonConvert.SerializeObject(platform);

            var response = await _httpClient.PutAsync(
                $"{_baseAdress}/platforms/{id}",
                new StringContent(platformJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
