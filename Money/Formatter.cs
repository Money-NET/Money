using System.Globalization;
using Money.Formatting;

namespace Money
{
    /// <summary>
    /// Creates a formatted price string according to several rules.
    /// </summary>
    /// <example>
    /// <code>
    ///     Money.new(100, "USD") #=> "$1.00"
    ///     Money.new(100, "GBP") #=> "£1.00"
    ///     Money.new(100, "EUR") #=> "€1.00"
    /// </code>
    /// </example>
    public class Formatter
    {
        private readonly Currency _currency;
        private readonly Rules _rules;

        #region Constructors

        public Formatter(Currency currency)
        {
            _currency = currency;
            _rules = new Rules();
        }

        public Formatter(Currency currency, Rules rules)
        {
            _currency = currency;
            _rules = rules;
        }

        #endregion

        public string Format(Money money)
        {
            var format = _currency.Format;
            var units = ((decimal)money.Fractional / (decimal)_currency.SubUnitToUnit);

            if (_rules.NoCents)
                format.CurrencyDecimalDigits = 0;

            var result = units.ToString("C", format);

            //if (result.ToString(CultureInfo.InvariantCulture).Contains($"{_currency.Format.CurrencyDecimalSeparator}00") |
            if (_rules.DropTrailingZeros)
                result = result.Replace($"{_currency.Format.CurrencyDecimalSeparator}00","");

            return result;
        }

    }
}
