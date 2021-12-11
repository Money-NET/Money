using System.Globalization;

namespace Money
{
    public class Formatter
    {
        private readonly Currency _currency;

        public Formatter(Currency currency)
        {
            _currency = currency;
        }

        public string Format(Money money)
        {
            var result = FormatNumber(money);

            return result;

        }

        public string FormatNumber(Money money)
        {
            // Format whole and decimal parts separately
            var (decimalPart, numberPart) = ExtractParts(money);

            // Format whole and decimal parts separately
            decimalPart = FormatDecimalPart(decimalPart);
            numberPart = FormatNumberPart(numberPart);

            return $"{numberPart}{_currency.DecimalMark}{decimalPart}";
        }

        private (string, string) ExtractParts(Money money)
        {
            var fractional = money.Fractional;

            // Translate subunits into units
            var units = ((decimal)fractional / (decimal)_currency.SubUnitToUnit);

            // Split the result and return whole and decimal parts separately
            var values = units.ToString("F", new CultureInfo("en-US")).Split('.');

            return (values[1], values[0]);
        }

        private string FormatDecimalPart(string value)
        {
            // Pad value, making up for missing zeroes at the end
            value = value.ljust(_currency.Exponent, '0');
        }

        private string FormatNumberPart(string value)
        {
            return null;
        }
    }
}
