using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PersonaFit.Auth.Dtos
{
    public class LoggedInUser
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Claim[] ToClaimss => [
            new Claim(ClaimTypes.NameIdentifier, Id),
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Email, Email),
        ];
        public LoggedInUser() { }
        public LoggedInUser(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static LoggedInUser? FromClaimsPrincipal(ClaimsPrincipal principal)
        {
            if (principal.Identity?.IsAuthenticated == true)
            {
                var id = principal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var name = principal.FindFirst(ClaimTypes.Name)!.Value;
                var email = principal.FindFirst(ClaimTypes.Email)!.Value;

                return new LoggedInUser(id, name, email);
            }
            return null;
        }
    }
}
