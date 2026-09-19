using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PersonaFit.Auth.Dtos
{
    public class LoggedInUser
    {
        // The precise claim type URI for Azure AD's Object ID (oid)
        private const string AzureObjectIdClaimType = "http://microsoft.com";

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Claim[] ToClaims() => [
            new Claim(AzureObjectIdClaimType, Id), // Use Azure OID
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Email, Email)
        ];

        public LoggedInUser() { }

        public LoggedInUser(string id, string name, string email)
        {
            Id = id;
            Name = name; // DisplayName
            Email = email;
        }

        public static LoggedInUser? FromClaimsPrincipal(ClaimsPrincipal principal)
        {
            if (principal.Identity?.IsAuthenticated == true)
            {
                var id = principal.FindFirst(AzureObjectIdClaimType)!.Value; // Use Azure OID
                var name = principal.FindFirst(ClaimTypes.Name)!.Value;
                var email = principal.FindFirst(ClaimTypes.Email)!.Value;

                return new LoggedInUser(id, name, email);
            }
            return null;
        }
    }
}