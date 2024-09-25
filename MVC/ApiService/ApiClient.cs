
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.ApiService
{
    public class ApiClient<T> : IApiClient<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5166/"); // URL base de la API

        }

        public Task<bool> DeleteAsync(string endpoint, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{endpoint}/listado");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();


                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }

            throw new HttpRequestException($"Error al obtener datos: {response.StatusCode}");

        }

        public async Task<T> GetByIdAsync(string endpoint, int id)
        {
            var response = await _httpClient.GetAsync($"{endpoint}/buscar{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                throw new Exception("Error al obtener el dato");
            }
        }

        public Task<bool> UpdateAsync(string endpoint, int id, T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IApiClient<T>.CreateAsync(string endpoint, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
