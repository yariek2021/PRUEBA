using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer
{
    public class UsuarioAcceso
    {
        [Key]
        public int UserId { get; set; }
        public bool Activo { get; set; }
    }
}
