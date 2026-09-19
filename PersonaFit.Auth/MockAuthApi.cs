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
            var loggedInUser = new LoggedInUser() { Id = "F8AC2C44-6BDB-4D54-851E-B661C83B8468", Name = "John Smith", Email = "john.smith@example.com" };
            var token = "SOME_SECURE_TOKEN_VALUE";
            return await Task.FromResult(new LoginResponseDto(loggedInUser, token));
        }
    }
}
