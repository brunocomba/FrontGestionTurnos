using Microsoft.AspNetCore.Mvc;
using MVC.ApiService;
using MVC.Controllers.Generic;
using MVC.Models;

namespace MVC.Controllers
{
    public class ClienteController : GenericController<Cliente>
    {
        public ClienteController(IApiClient<Cliente> apiClient): base(apiClient, "clientes")
        {

        }


    }
}
