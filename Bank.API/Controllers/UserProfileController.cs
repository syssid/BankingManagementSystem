using Bank.Application.Contracts;
using Bank.Application.DTO.Request.UserProfile;
using Bank.Application.DTO.Response;
using Bank.Application.DTO.Response.UserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bank.API.Controllers
{
    [Route("api/user/profile")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfile _userProfile;

        public UserProfileController(IUserProfile userProfile)
        {
            _userProfile = userProfile;
        }

        [HttpGet]
        public async Task<ActionResult<UserProfileDetailsResponse>> GetProfile()
        {
            int userId = GetUserId();
            var result = await _userProfile.GetProfileAsync(userId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserProfileResponse>> CreateProfile(
            [FromBody] CreateUserProfileDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int userId = GetUserId();
            var result = await _userProfile.CreateProfileAsync(userId, dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateUserProfileResponse>> UpdateProfile(
            [FromBody] UpdateUserProfileDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int userId = GetUserId();
            var result = await _userProfile.UpdateProfileAsync(userId, dto);

            return Ok(result);
        }

        private int GetUserId()
        {
            return int.Parse(
                User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value
            );
        }
    }
}
