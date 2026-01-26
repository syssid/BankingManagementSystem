using Bank.UI.Models.Profile.Request;
using Bank.UI.Models.Profile.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            //AttachToken(_httpClient);
            var response = await _httpClient.GetAsync("api/user/profile");

            if (!response.IsSuccessStatusCode)
                return PartialView("_ProfileError");

            var model = await response.Content.ReadFromJsonAsync<UserProfileDetailsResponse>();
            if (!model.Flag)
            {
                model = model with
                {
                    Name = User.Identity?.Name,
                    Email = User.Claims
                                .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
                };
            }
            return PartialView("_ProfilePartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserDetails(ProfileViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/profile-add", model);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Update failed");

            return Ok("Profile updated successfully");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserDetails (ProfileViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync("api/user/profile", model);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Update failed");

            return Ok("Profile updated successfully");
        }
    }
}
