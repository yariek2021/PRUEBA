using System.Globalization;

namespace CommonLayer.Extensions
{
    public static class DecimalExtension
    {
        public static string Currency(this decimal value)
        {
            return  string.Format(new CultureInfo("en-US"), "{0:C}", value);
        }

        public static string CurrencyEmty(this decimal ?value)
        {
            if (value != null)
            {
                return string.Format(new CultureInfo("en-US"), "{0:C}", value);
            }
            else
            {
                return "-";
            }
        
        }

        public static string CurrencyOnlyNumber(this decimal? value)
        {
            if (value != null)
            {
                return string.Format(new CultureInfo("en-US"), "{0:N}", value);
            }
            else
            {
                return "-";
            }

        }


    }
}
