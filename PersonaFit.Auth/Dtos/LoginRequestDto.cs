using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonaFit.Auth.Dtos
{
    public class LoginRequestDto
    {
        [Required] 
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
