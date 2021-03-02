using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nomina2018.ViewModels
{
    public class UserUpdateLoginViewModel
    {
        [Required]
        public string IdColaborador { get; set; }

    }
}
