using System.Globalization;
using Money.Formatting;

namespace Money
{
    /// <summary>
    /// Creates a formatted price string according to several rules.
    /// </summary>
    /// <example>
    /// <code>
    ///     new Money(100, Currency.USD) #=> "$1.00"
    ///     new Money(100, Currency.GBP) #=> "£1.00"
    ///     nwe Money(100, Currency.EUR) #=> "€1.00"
    /// 
    ///     # Same thing.
    ///     new Money(100, Currency.USD).ToString(showSymbol: true) #=> "$1.00"
    ///     new Money(100, Currency.GBP).ToString(showSymbol: true) #=> "£1.00"
    ///     new Money(100, Currency.EUR).ToString(showSymbol: true) #=> "€1.00"
    ///
    ///     # You can specify a false expression or an empty string to disable
    ///     # pre-pending a money symbol.
    ///     new Money(100, Currency.USD).ToString(showSymbol: false) #=> "1.00"
    ///
    ///     # If the symbol for the given currency isn't known, then it will default
    ///     # to "¤" as symbol.
    ///     new Money(100, Currency.AWG).format(showSymbol: true) #=> "¤1.00"
    ///
    ///     # You can specify a string as value to enforce using a particular symbol.
    ///     new Money(100, Currency.AWG).ToString(symbol: "ƒ") #=> "ƒ1.00"
    ///
    ///     # You can specify a indian currency format
    ///     new Money(10000000, Currency.INR).ToString(south_asian_number_formatting: true) #=> "1,00,000.00"
    ///     new Money(10000000).ToString(south_asian_number_formatting: true) #=> "$1,00,000.00"
    ///
    ///     @option Rules [Boolean, nil] :symbol_before_without_space (true) Whether
    ///       a space between the money symbol and the amount should be inserted when
    ///       +:symbol_position+ is +:before+. The default is true (meaning no space). Ignored
    ///       if +:symbol+ is false or +:symbol_position+ is not +:before+.
    /// </code>
    /// </example>
    /// <example>
    /// <code>
    ///   new Money(100, Currency.USD).ToString(positivePosition: Position.AfterWithSpace)  #=> "1.00 $"
    ///   new Money(100, Currency.USD).ToString(positivePosition: Position.After)           #=> "1.00$"
    /// 
    ///   new Money(100, Currency.SEK).ToString(positivePosition: Position.BeforeWithSpace) #=> "kr 1.00"
    ///   new Money(100, Currency.SEK).ToString(positivePosition: Position.Before)          #=> "1.00kr"
    /// </code>
    /// </example>
    /// <example>
    /// <code>
    ///   # You can specify to display the sign before the symbol for negative numbers
    ///   new Money(-100, Currency.GBP).ToString(SignBeforeSymbol: true)  #=> "-£1.00"
    ///   new Money(-100, Currency.GBP).ToString(SignBeforeSymbol: false) #=> "£-1.00"
    ///   new Money(-100, Currency.GBP).ToString()                        #=> "£-1.00"
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
            var format = (NumberFormatInfo)_currency.Format.Clone();

            #region Rules

            if (_rules.Disambiguate.HasValue && !string.IsNullOrWhiteSpace(_currency.DisambiguateSymbol))
                format.CurrencySymbol = _currency.DisambiguateSymbol;

            if (_rules.NegativePosition.HasValue)
                format.CurrencyNegativePattern = (int)_rules.NegativePosition;

            if (_rules.NoCents.HasValue && _rules.NoCents.Value)
                format.CurrencyDecimalDigits = 0;

            if (_rules.PositivePosition.HasValue)
                format.CurrencyPositivePattern = (int)_rules.PositivePosition;

            if (_rules.ShowSymbol.HasValue && !_rules.ShowSymbol.Value)
                format.CurrencySymbol = string.Empty;

            #endregion

            var units = ((decimal)money.Fractional / (decimal)_currency.SubUnitToUnit);
            var result = units.ToString("C", format);

            #region Rules

            if (_rules.DropTrailingZeros.HasValue && _rules.DropTrailingZeros.Value)
                result = result.Replace($"{_currency.Format.CurrencyDecimalSeparator}00", "");

            if (_rules.ShowSymbol.HasValue && !_rules.ShowSymbol.Value)
                result = result.Trim(' ');

            #endregion

            return result;
        }
    }
}
