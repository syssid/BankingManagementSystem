using Bank.UI.Models.Account.Request;
using Bank.UI.Models.Account.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Bank.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly HttpClient _httpClient;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BankAPI");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (IsLoggedIn)
                return RedirectToAction("Index", "Dashboard");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var apiRequest = new { vm.Email, vm.Password };

            var response = await _httpClient
                .PostAsJsonAsync("api/user/login", apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid email or password";
                return View(vm);
            }

            var result = await response
                .Content.ReadFromJsonAsync<LoginResponseViewModel>();

            HttpContext.Session.SetString("Token", result!.Token);

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
