using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using PersonaFit.Auth;

namespace PersonaFit.Core.Components.Pages
{
    public partial class Home
    {
        [Inject] public required NavigationManager NavigationManager { get; set; }
        [Inject] public required AppAuthStateProvider AppAuthStateProvider { get; set; }
        [CascadingParameter] public Task<AuthenticationState>? AuthState {  get; set; }
        private void NavigateToLogin()
        {
            try
            {
                NavigationManager.NavigateTo("login", replace: true);
            }
            catch (Exception ex) 
            {
                var message = ex.Message;
            }
        }

        private void Logout()
        {
            AppAuthStateProvider.Logout();
        }

    }
}