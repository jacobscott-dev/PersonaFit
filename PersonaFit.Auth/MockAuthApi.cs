using PersonaFit.Auth.Dtos;
using PersonaFit.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonaFit.Auth
{
    public class MockAuthApi : IAuthApi
    {
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var loggedInUser = new LoggedInUser() { Id = "1", Name = "John Doe", Email = "John@mail.com" };
            var token = "SOME_SECURE_TOKEN_VALUE";
            return await Task.FromResult(new LoginResponseDto(loggedInUser, token));
        }
    }
}
