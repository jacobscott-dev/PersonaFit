using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using PersonaFit.Auth;

namespace PersonaFit.Core
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            // auth
            builder.Services.AddAuthorizationCore();
            // register my services here
            builder.Services.AddTransient<IAuthApi, MockAuthApi>();
            builder.Services.AddSingleton<AuthenticationStateProvider, AppAuthStateProvider>();

            return builder.Build();
        }
    }
}
