using System;


namespace DomainLayer
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NSS { get; set; }
        public int PuestoId { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public bool Estatus { get; set; }
        public virtual Puesto Puesto { get; set; }
        //public virtual SueldoEmpleado SueldoEmpleado { get; set; }
    }
}
