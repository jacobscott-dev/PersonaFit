using System;
using System.Collections.Generic;
using System.Text;

namespace PersonaFit.Auth.Dtos
{
    public record LoginResponseDto(LoggedInUser user, string token);
}
