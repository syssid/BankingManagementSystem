using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.DTO.Response.UserProfile
{
    public record UpdateUserProfileResponse(bool Flag, string Message = null!);
}
