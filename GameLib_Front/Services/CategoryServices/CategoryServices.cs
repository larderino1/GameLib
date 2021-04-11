using DbManager.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameLib_Front.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseAdress;

        public CategoryServices(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();

            _baseAdress = configuration.GetConnectionString("GameLibServerUri");
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            var categoryJson = JsonConvert.SerializeObject(category);

            var response = await _httpClient.PostAsync(
                $"{_baseAdress}/categories",
                new StringContent(categoryJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseAdress}/categories/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Category>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }

        public async Task<IEnumerable<Category>> GetCategoryListAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseAdress}/categories");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Category>>(await response.Content.ReadAsStringAsync());
            }

            return Enumerable.Empty<Category>();
        }

        public async Task<bool> UpdateCategoryAsync(Guid id, Category category)
        {
            var categoryJson = JsonConvert.SerializeObject(category);

            var response = await _httpClient.PutAsync(
                $"{_baseAdress}/categories/{id}",
                new StringContent(categoryJson, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
