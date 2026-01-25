using Bank.UI.Models.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bank.UI.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly HttpClient _httpClient;

        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BankAPI");
        }

        public async Task<IActionResult> ProfilePartial()
        {
            AttachToken(_httpClient);
            var response = await _httpClient.GetAsync("api/user/profile");

            if (!response.IsSuccessStatusCode)
                return PartialView("_ProfileError");

            var model = await response.Content.ReadFromJsonAsync<ProfileViewModel>();
            return PartialView("_ProfilePartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProfileViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync("api/user/profile", model);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Update failed");

            return Ok("Profile updated successfully");
        }
    }
}
