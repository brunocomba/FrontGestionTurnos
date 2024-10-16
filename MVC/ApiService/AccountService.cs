﻿using Newtonsoft.Json;
using System.Text;

namespace MVC.ApiService
{
    public class AccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://backgestionturnos.azurewebsites.net/"); // URL base de la API

        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var loginData = new { email, password };
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("administradores/login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token; // Este sería el JWT token devuelto por la API
            }

            return null; // Manejar errores según sea necesario
        }
    }
}
