using Microsoft.AspNetCore.Components;
using PersonaFit.Auth;
using PersonaFit.Auth.Dtos;
using PersonaFit.Auth.Interfaces;

namespace PersonaFit.Core.Components.Pages
{
    public partial class Login
    {
        [Inject] public required IAuthenticationService AuthenticationService { get; set; }
        [Inject] public required AppAuthStateProvider AppAuthStateProvider { get; set; }
        [Inject] public required NavigationManager NavigationManager { get; set; }
        private LoginRequestDto _model { get; set; } = new();

        private async Task LoginAsync()
        {
            var loginResponse = await AuthenticationService.LoginAsync(_model);
            AppAuthStateProvider.LoginAsync(loginResponse);
            NavigationManager.NavigateTo("/", replace: true);
        }
    }
}