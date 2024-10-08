using Newtonsoft.Json;
using System.Text;

namespace MVC.ApiService
{
    public class AdministradorService
    {
        private readonly HttpClient _httpClient;

        public AdministradorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://backgestionturnos.azurewebsites.net/"); // URL base de la API

        }

      
    }
}
