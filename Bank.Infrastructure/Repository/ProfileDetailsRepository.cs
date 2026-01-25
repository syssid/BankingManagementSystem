using Bank.Application.Contracts;
using Bank.Application.DTO.Request.UserProfile;
using Bank.Application.DTO.Response.UserProfile;
using Bank.Domain.Entities;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Repository
{
    public class ProfileDetailsRepository : IUserProfile
    {
        private readonly AppDbContext _context;

        public ProfileDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfileDetailsResponse> GetProfileAsync(int userId)
        {
            var profile = await _context.UserProfiles
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.ApplicationUserId == userId);

            if (profile == null)
                return new UserProfileDetailsResponse(
                    false,
                    "Profile not found"
                );

            return new UserProfileDetailsResponse(
                true,
                "Profile fetched successfully",
                profile.ApplicationUserId,
                profile.ApplicationUser?.Name,
                profile.ApplicationUser?.Email,
                profile.Mobile,
                profile.Address,
                profile.DateOfBirth
            );
        }

        // 🔹 CREATE PROFILE
        public async Task<CreateUserProfileResponse> CreateProfileAsync(
     int userId,
     CreateUserProfileDTO createUserProfileDTO)
        {
            var exists = await _context.UserProfiles
                .AnyAsync(x => x.ApplicationUserId == userId);

            if (exists)
                return new CreateUserProfileResponse(
                    false,
                    "Profile already exists"
                );

            var profile = new UserProfile
            {
                // ✅ DO NOT SET Id
                ApplicationUserId = userId,   // ✅ FK
                Mobile = createUserProfileDTO.Mobile,
                Address = createUserProfileDTO.Address,
                DateOfBirth = createUserProfileDTO.DateOfBirth,
                Gender = createUserProfileDTO.Gender
            };

            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return new CreateUserProfileResponse(
                true,
                "Profile created successfully"
            );
        }

        // 🔹 UPDATE PROFILE
        public async Task<UpdateUserProfileResponse> UpdateProfileAsync(
            int userId,
            UpdateUserProfileDTO dto)
        {
            var profile = await _context.UserProfiles
                .FirstOrDefaultAsync(x => x.ApplicationUserId == userId);

            if (profile == null)
                return new UpdateUserProfileResponse(
                    false,
                    "Profile not found"
                );

            profile.Mobile = dto.Mobile;
            profile.Address = dto.Address;
            profile.DateOfBirth = dto.DateOfBirth;

            await _context.SaveChangesAsync();

            return new UpdateUserProfileResponse(
                true,
                "Profile updated successfully"
            );
        }
    }
}
