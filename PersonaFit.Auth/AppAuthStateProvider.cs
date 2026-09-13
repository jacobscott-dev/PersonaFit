using Microsoft.AspNetCore.Components.Authorization;
using PersonaFit.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PersonaFit.Auth
{
    public class AppAuthStateProvider : AuthenticationStateProvider, IDisposable
    {
        private const string AuthType = "app-auth";
        private const string StorageKey = "app-storage-key";// can be anything
        private readonly static Task<AuthenticationState> _emptyAuthTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        private static Task<AuthenticationState> _currentAuthTask = _emptyAuthTask;

        public string? Token {  get; private set; }
        public LoggedInUser? CurrentUser { get; private set; }

        public AppAuthStateProvider()
        {
            AuthenticationStateChanged += HandleAuthenticationStateChanged;
        }

        public async void HandleAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            // do something?
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var serializedLoginResponse = Preferences.Default.Get<string?>(StorageKey, null);
            if (serializedLoginResponse is not null)
            {
                var loginResponse = JsonSerializer.Deserialize<LoginResponseDto>(serializedLoginResponse)!;
                Login(loginResponse, saveToStorage: false);
                return _currentAuthTask;
            }
            return _emptyAuthTask;
        }

        public void Login(LoginResponseDto loginResponse, bool saveToStorage = true)
        {
            var claims = loginResponse.User.ToClaims();
            var identity = new ClaimsIdentity(claims, AuthType);
            var principal = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(principal);

            Token = loginResponse.Token;
            CurrentUser = loginResponse.User;

            _currentAuthTask = Task.FromResult(authState);
            NotifyAuthenticationStateChanged(_currentAuthTask);

            // saves data to device so its kept when user closes app
            if (saveToStorage)
                Preferences.Default.Set<string>(StorageKey, JsonSerializer.Serialize(loginResponse));
        }

        public void Logout()
        {
            Token = null;
            CurrentUser = null;

            _currentAuthTask = _emptyAuthTask;
            NotifyAuthenticationStateChanged(_emptyAuthTask);

            Preferences.Default.Remove(StorageKey);
        }

        public void Dispose()
        {
            AuthenticationStateChanged -= HandleAuthenticationStateChanged;
        }
    }
}
