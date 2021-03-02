using System;
using System.Collections.Generic;
using System.Text;

namespace DtoLayer
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Usuario { get; set; }

    }

    public class UserUpdateDto
    {
        public int Id { get; set; }

    }
}
