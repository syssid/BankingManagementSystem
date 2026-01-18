using Bank.UI.Models.Account.Request;
using Bank.UI.Models.Account.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Bank.UI.Controllers
{
    public class RegistrationController : BaseController
    {
        private readonly HttpClient _httpClient;

        public RegistrationController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BankAPI");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (IsLoggedIn)
                return RedirectToAction("Index", "Dashboard");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var apiRequest = new
            {
                Name = vm.FullName,
                vm.Email,
                vm.Password,
                vm.ConfirmPassword
            };

            var response = await _httpClient.PostAsJsonAsync(
                "api/user/register",
                apiRequest
            );

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Registration failed.";
                return View(vm);
            }

            var result = await response.Content
                .ReadFromJsonAsync<RegistrationResponseViewModel>();

            TempData["Success"] = result?.Message;

            return RedirectToAction("Login", "Login");
        }
    }
}
