using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthWndCore.BusinessModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="Emile is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = " Password is incorrect")]
        public string ConfirmPassword { get; set; }
    }
}
