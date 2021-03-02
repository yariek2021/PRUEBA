using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nomina2018.ViewModels
{
    public class EditRoleViewModel
    {
        //public EditRoleViewModel()
        //{
        //    Users = new List<string>();
        //}

        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
