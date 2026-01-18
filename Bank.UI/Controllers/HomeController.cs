using Bank.UI.Models.Account.Request;
using Bank.UI.Models.Account.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bank.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BankAPI");
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            if (IsLoggedIn)
                return RedirectToAction("Index", "Dashboard");

            return View();
        }
    }
}
