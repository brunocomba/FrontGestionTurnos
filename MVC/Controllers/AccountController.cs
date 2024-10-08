using Microsoft.AspNetCore.Mvc;
using MVC.ApiService;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                return RedirectToAction("Index", "Home"); // Redirige si ya está autenticado
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _accountService.LoginAsync(username, password);

            if (token != null)
            {
                // Guardar el token en la sesión o cookie
                HttpContext.Session.SetString("JWToken", token);
                ViewBag.Error = "Login exitoso!";
                return RedirectToAction("Index", "Home");


            }

            // Si falla el login
            ViewBag.Error = "Usuario y/o passwordor invalidos";
            return View("Index");
        }
            
    }
}
