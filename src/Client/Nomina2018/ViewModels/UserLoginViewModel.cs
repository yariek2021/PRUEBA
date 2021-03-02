using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nomina2018.ViewModels
{
    public class UserLoginViewModel
    {
        public string ReturnUrl { get; set; }
        [Required(ErrorMessage = "Ingrese Usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ingrese Contraseña")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
