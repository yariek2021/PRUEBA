using System;
using System.Globalization;

namespace CommonLayer.Extensions
{
    public static class FechaExtension
    {
        public static string FechaCorta(this DateTime fecha)
        {
            return  string.Format(new CultureInfo("en-US"), "{0:MM/dd/yyyy}", fecha);
        }

        public static string FechaLarga(this DateTime fecha)
        {
            return string.Format(new CultureInfo("es-ES"), "{0: dd MMMM yyyy}", fecha);
        }

        public static string FechaInicio(this DateTime fecha)
        {
            return string.Format(new CultureInfo("es-ES"), "{0: dd MMMM }", fecha);
        }

        public static string FechaMedio(this DateTime fecha)
        {
            return string.Format(new CultureInfo("es-ES"), "{0: dd MMMM yyyy}", fecha);
        }

    }
}
