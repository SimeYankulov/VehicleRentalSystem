using System.Globalization;

namespace VehicleRentalSystem.Entities
{
    public static class DecimalToStringConverter
    {
        // Using it a lot in the Rental class so i made its own function
        public static string ToInvariantString(this decimal value)
        {
            return value.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
