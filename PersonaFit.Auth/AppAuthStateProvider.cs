using Microsoft.AspNetCore.Components.Authorization;
using PersonaFit.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PersonaFit.Auth
{
    public class AppAuthStateProvider : AuthenticationStateProvider
    {
        private const string AuthType = "app-auth";
        private readonly static Task<AuthenticationState> _emptyAuthTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return _emptyAuthTask;
        }

        public void LoginAsync(LoginResponseDto loginResponse)
        {
            var claims = loginResponse.User.ToClaims();
            var identity = new ClaimsIdentity(claims, AuthType);
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public void Logout()
        {
            NotifyAuthenticationStateChanged(_emptyAuthTask);
        }
    }
}
