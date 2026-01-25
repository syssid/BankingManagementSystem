using Bank.Application.DTO.Request.UserProfile;
using Bank.Application.DTO.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Contracts
{
    public interface IUserProfile
    {
        Task<UserProfileDetailsResponse> GetProfileAsync(int userId);
        Task<CreateUserProfileResponse> CreateProfileAsync(int userId,CreateUserProfileDTO createUserProfileDTO);
        Task<UpdateUserProfileResponse> UpdateProfileAsync(int userId, UpdateUserProfileDTO updateUserProfileDTO);
    }
}
