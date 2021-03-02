using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Usuario: IdentityUser
    {
        //[Key]
        public int UsuarioId { get; set; }
        public string Alias { get; set; }
        public string NombreUsuario { get; set; }
        public string Contra { get; set; }
        public bool Acceso { get; set; }

    }
}
