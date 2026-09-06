using PersonaFit.Auth.Dtos;

namespace PersonaFit.Auth
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task LogoutAsync();
    }
    public class AuthenticationService : IAuthenticationService
    {
        private IAuthApi _api { get; set; }
        public AuthenticationService(IAuthApi api) 
        { 
            if (api == null) 
                throw new ArgumentNullException(nameof(api));
            
            _api = api;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
           return await _api.LoginAsync(request);
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
