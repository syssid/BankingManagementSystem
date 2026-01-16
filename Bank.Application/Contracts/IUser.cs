using Bank.Application.DTO.Request;
using Bank.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Contracts
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);

        Task<LoginResponse> LoginUserAsync(LoginDTO loginDTO);
    }
}
