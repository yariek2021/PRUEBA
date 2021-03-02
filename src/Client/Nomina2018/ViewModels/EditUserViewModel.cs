using DtoLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nomina2018.ViewModels
{
    public class EditUserViewModel
    {

        public int Id { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public int IdColaborador { get; set; }

        public List<string> Claims { get; set; }

        public List<RoleDto> Roles { get; set; }

        public int RoleId { get; set; }
        public bool Activo { get; set; }

    }
}
