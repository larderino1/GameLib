using DbManager.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameLib_Front.Services.ModeServices
{
    public class ModeServices : IModeServices
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseAdress;

        public ModeServices(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();

            _baseAdress = configuration.GetConnectionString("GameLibServerUri");
        }

        public async Task<bool> CreateModeAsync(Mode mode)
        {
            var modeJson = JsonConvert.SerializeObject(mode);

            var response = await _httpClient.PostAsync(
                $"{_baseAdress}/modes",
                new StringContent(modeJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteModeAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseAdress}/modes/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Mode> GetModeByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/modes/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Mode>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<Mode>> GetModeListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/modes");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Mode>>(await response.Content.ReadAsStringAsync());
            }

            return Enumerable.Empty<Mode>();
        }

        public async Task<bool> UpdateModeAsync(Guid id, Mode mode)
        {
            var modeJson = JsonConvert.SerializeObject(mode);

            var response = await _httpClient.PutAsync(
                $"{_baseAdress}/modes/id",
                new StringContent(modeJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
