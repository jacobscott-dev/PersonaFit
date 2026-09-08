using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace PersonaFit.Core.Components.Pages
{
    public partial class Home
    {
        [Inject] public required NavigationManager NavigationManager { get; set; }
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
    }
}