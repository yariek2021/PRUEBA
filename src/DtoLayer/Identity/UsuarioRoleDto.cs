using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoLayer
{
    public class UsuarioRoleDto
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }

    }

    public class UsuarioRoleUpdate: UsuarioRoleDto
    {

    }
}
