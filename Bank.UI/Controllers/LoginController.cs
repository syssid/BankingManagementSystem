using Bank.UI.Models.Account.Request;
using Bank.UI.Models.Account.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

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
            {
                return View("~/Views/Home/Index.cshtml", vm);
            }

            var apiRequest = new
            {
                vm.Email,
                vm.Password
            };

            var response = await _httpClient
                .PostAsJsonAsync("api/user/login", apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Unable to login. Please try again.";
                return View("~/Views/Home/Index.cshtml", vm);
            }

            var result = await response
                .Content.ReadFromJsonAsync<LoginResponseViewModel>();

            // 🚫 User not found / invalid credentials
            if (result == null || result.Flag == false)
            {
                ViewBag.Error = result?.Message ?? "Invalid email or password";
                return View("~/Views/Home/Index.cshtml", vm);
            }

            // ✅ SUCCESS
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(result.Token!);

            var identity = new ClaimsIdentity(
                jwt.Claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            HttpContext.Session.SetString("Token", result.Token!);

            return RedirectToAction("Index", "Dashboard");
        }

    }
}
