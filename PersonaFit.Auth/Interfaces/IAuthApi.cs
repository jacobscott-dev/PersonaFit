using PersonaFit.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonaFit.Auth.Interfaces
{
    public interface IAuthApi
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
