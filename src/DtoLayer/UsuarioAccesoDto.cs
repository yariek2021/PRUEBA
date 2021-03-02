using System;
using System.Collections.Generic;
using System.Text;

namespace DtoLayer
{
    public class UsuarioAccesoDto
    {
        public int UserId { get; set; }
        public bool Activo { get; set; }
    }

    public class UsuarioAccesoUpdateDto: UsuarioAccesoDto
    {

    }
}
