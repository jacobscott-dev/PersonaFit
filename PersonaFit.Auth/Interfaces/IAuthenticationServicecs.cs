using PersonaFit.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonaFit.Auth.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task LogoutAsync();
    }
}
