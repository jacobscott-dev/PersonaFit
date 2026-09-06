using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PersonaFit.Auth
{
    public class AppAuthStateProvider : AuthenticationStateProvider
    {
        private readonly static Task<AuthenticationState> _emptyAuthTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return _emptyAuthTask;
        }
    }
}
