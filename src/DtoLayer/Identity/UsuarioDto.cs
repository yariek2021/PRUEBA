

using System;

namespace DtoLayer
{
    public class UsuarioDto
    {

        public int UsuarioId { get; set; }
        public string Alias { get; set; }
        public string NombreUsuario { get; set; }
        public string Contra { get; set; }
        public bool Acceso { get; set; }
        public string Role { get; set; }
    }


}
