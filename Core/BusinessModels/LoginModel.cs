using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.BusinessModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Emile is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
