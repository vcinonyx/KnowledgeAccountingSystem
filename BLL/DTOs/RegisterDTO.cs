using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [RegularExpression("^[A-Z][a-z]*(\\s[A-Z][a-z]*)+$")]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
  
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
        ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        public string Password { get; set; }
    }
}
