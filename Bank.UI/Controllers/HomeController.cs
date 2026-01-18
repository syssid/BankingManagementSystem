using Bank.UI.Models.Account.Request;
using Bank.UI.Models.Account.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bank.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BankAPI");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var apiRequest = new{vm.Email,vm.Password};

            var response = await _httpClient.PostAsJsonAsync("api/user/login", apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid login";
                return View(vm);
            }

            var result = await response.Content.ReadFromJsonAsync<LoginResponseViewModel>();

            HttpContext.Session.SetString("Token", result!.Token);
            return RedirectToAction("Index", "Dashboard");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
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
            return RedirectToAction("Index");
        }

                public IActionResult Logout()
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Index", "Home");
                }
    }
}
