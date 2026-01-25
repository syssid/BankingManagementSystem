using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.DTO.Response.UserProfile
{
    public record UserProfileDetailsResponse(bool Flag,string Message = null!,int UserId = 0,string? Name = null,string? Email = null,string? Mobile = null,string? Address = null,DateTime? DateOfBirth = null);
}
