using Money.Bank.Interfaces;
using Money.Enums;
using Money.Formatting;
using System;

namespace Money
{
    /// <summary>
    /// "Money is any object or record that is generally accepted as payment for
    /// goods and services and repayment of debts in a given socioeconomic context
    /// or country." -Wikipedia
    ///
    /// An instance of Money represents an amount of a specific currency.
    ///
    /// Money is a value object and should be treated as immutable.
    ///
    /// @see http://en.wikipedia.org/wiki/Money
    /// </summary>
    public class Money : IComparable, IEquatable<Money>
    {
        public static IBank Bank { get; private set; } = new Bank.VariableExchange();
        public Currency Currency;
        public long Fractional;
        public MidpointRounding Rounding;

        protected Money(MidpointRounding rounding = MidpointRounding.ToEven)
        {
            Rounding = rounding;
        }

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="fractional"></param>
        /// <param name="currency"></param>
        /// <param name="rounding"></param>
        public Money(long fractional, Currency currency, MidpointRounding rounding = MidpointRounding.ToEven)
            : this(rounding)
        {
            Currency = currency;
            Fractional = fractional;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fractional"></param>
        /// <param name="currency"></param>
        /// <param name="rounding"></param>
        public Money(int fractional, Currency currency, MidpointRounding rounding = MidpointRounding.ToEven)
            : this(rounding)
        {
            Currency = currency;
            Fractional = fractional;
        }

        #endregion

        #region Methods

        public long Cents => Fractional;

        //TODO: Move to Arithmetic.cs?
        public bool Positive => Fractional > 0;
        public bool Negative => Fractional < 0;

        /// <summary>
        /// Creates a new Money object of value given in the +unit+ of the given
        /// +currency+.
        /// </summary>
        /// <returns>[Money]</returns>
        /// <example>
        /// <code>
        ///     Money.FromAmount(23.45, Currency.USD) # => #<Money Fractional:2345 Currency:USD>
        ///     Money.FromAmount(23.45, Currency.JPY) # => #<Money Fractional:23 Currency:JPY>
        /// </code>
        /// </example>
        public static Money FromAmount(double amount, Currency currency)
        {
            var value = (long)(amount * currency.SubUnitToUnit);

            return new Money(value, currency);
        }

        //public static Money FromAmount(double amount, Currency currency)
        //{
        //    var value = (long)(amount * currency.SubUnitToUnit);

        //    return new Money(value, currency);
        //}

        public static Money FromCents(long amount, Currency currency)
        {
            return new Money(amount, currency);
        }

        /// <summary>
        /// Round a given amount of money to the nearest possible amount in cash value. For
        /// example, in Swiss franc (CHF), the smallest possible amount of cash value is
        /// CHF 0.05. Therefore, this method rounds CHF 0.07 to CHF 0.05, and CHF 0.08 to
        /// CHF 0.10.
        /// </summary>
        /// <returns></returns>
        public decimal RoundToNearestCashValue()
        {
            var value = Math.Round(((decimal)Fractional / (decimal)Currency.SmallestDenomination), Rounding) * Currency.SmallestDenomination;

            return value;
        }

        public Money SetBank(IBank bank)
        {
            Bank = bank;

            return this;
        }

        public Money SetRounding(MidpointRounding rounding)
        {
            Rounding = rounding;

            return this;
        }

        public Money Exchange(Currency currency)
        {
            return Bank.Exchange(this, currency);
        }

        public bool Equals(Money other)
        {
            if (other == null)
                return false;

            return Currency.Code == other.Currency.Code &&
                   Fractional == other.Fractional;
        }

        public int CompareTo(object obj)
        {
            var money = (Money)obj;
            return Fractional.CompareTo(money.Fractional) +
                   Currency.CompareTo(money.Currency);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Creates a formatted price string according to several rules.
        /// </summary>
        /// <param name="disambiguate"></param>
        /// <param name="dropTrailingZeros"></param>
        /// <param name="roundedInfinitePrecision"></param>
        /// <param name="negativePosition"></param>
        /// <param name="noCents"></param>
        /// <param name="noCentsIfWhole"></param>
        /// <param name="positivePosition"></param>
        /// <param name="showPositiveSign"></param>
        /// <param name="showSymbol"></param>
        /// <returns></returns>
        public string ToString(
            bool? disambiguate = null,
            bool? dropTrailingZeros = null,
            bool? roundedInfinitePrecision = null,
            NegativePosition? negativePosition = null,
            bool? noCents = null,
            bool? noCentsIfWhole = null,
            PositivePosition? positivePosition = null,
            bool? showPositiveSign = null,
            bool? showSymbol = null)
        {
            return new Formatter(Currency, new Rules
            {
                Disambiguate = disambiguate,
                DropTrailingZeros = dropTrailingZeros,
                RoundedInfinitePrecision = roundedInfinitePrecision,
                NegativePosition = negativePosition,
                NoCents = noCents,
                NoCentsIfWhole = noCentsIfWhole,
                PositivePosition = positivePosition,
                ShowPositiveSign = showPositiveSign,
                ShowSymbol = showSymbol
            }).Format(this);
        }

        public override int GetHashCode()
        {
            //return HashCode.Combine(Currency.GetHashCode(), Fractional.GetHashCode());
            return new { Currency, Fractional }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;

            return Fractional.Equals(money.Fractional) &&
                   Currency.Equals(money.Currency);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compares +self+ with +other_currency+ and returns +true+ if the are the
        /// same or if their +id+ attributes match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>[Boolean]</returns>
        public static bool operator ==(Money lhs, Money rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares +self+ with +other_currency+ and returns +true+ if the are the
        /// same or if their +id+ attributes match.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>[Boolean]</returns>
        public static bool operator !=(Money lhs, Money rhs)
        {
            return !(lhs == rhs);
        }

        public static Money operator +(Money lhs, Money rhs)
        {
            return new Money((lhs.Fractional + rhs.Fractional), lhs.Currency, lhs.Rounding);
        }

        public static Money operator +(Money lhs, long value)
        {
            return new Money((lhs.Fractional + value), lhs.Currency, lhs.Rounding);
        }

        public static Money operator -(Money lhs, Money rhs)
        {
            return new Money((lhs.Fractional - rhs.Fractional), lhs.Currency, lhs.Rounding);
        }
        public static Money operator -(Money lhs, long value)
        {
            return new Money((lhs.Fractional - value), lhs.Currency, lhs.Rounding);
        }

        public static Money operator *(Money lhs, long value)
        {
            return new Money((lhs.Fractional * value), lhs.Currency, lhs.Rounding);
        }

        public static Money operator /(Money lhs, long value)
        {
            return new Money((lhs.Fractional / value), lhs.Currency, lhs.Rounding);
        }

        #endregion
    }
}
