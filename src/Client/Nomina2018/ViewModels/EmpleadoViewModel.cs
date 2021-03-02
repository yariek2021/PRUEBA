using DtoLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace Nomina2018.ViewModels
{
    public class EmpleadoViewModel
    {
        public EmpleadoBaseDto empleado { get; set; }
        public IEnumerable<SelectListItem> Puestos { get; set; }
    }
}
