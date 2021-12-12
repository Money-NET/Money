using System;
using Money.Bank.Interfaces;
using Money.Enums;
using Money.Formatting;

namespace Money
{
    /// <summary>
    /// "Money is any object or record that is generally accepted as payment for
    /// goods and services and repayment of debts in a given socio-economic context
    /// or country." -Wikipedia
    ///
    /// An instance of Money represents an amount of a specific currency.
    ///
    /// Money is a value object and should be treated as immutable.
    ///
    /// @see http://en.wikipedia.org/wiki/Money
    /// </summary>
    public class Money //: IComparable
    {
        public IBank Bank;
        public Currency Currency;
        public long Fractional;
        public MidpointRounding Rounding = MidpointRounding.ToEven;

        protected Money(MidpointRounding rounding = MidpointRounding.ToEven)
        {
            Bank = new Bank.VariableExchange();
            Rounding = rounding;
        }

        #region Constructors

        /// <summary>
        /// Creates a new Money object of value given in the +unit+ of the given
        /// +currency+.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currency"></param>
        /// <param name="rounding"></param>
        public Money(decimal value, Currency currency, MidpointRounding rounding = MidpointRounding.ToEven)
            : this(rounding)
        {
            Currency = currency;
            Fractional = (long)Math.Round((value * currency.SubUnitToUnit), rounding);
        }

        /// <summary>
        /// Creates a new Money object of value given in the +unit+ of the given
        /// +currency+.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currency"></param>
        /// <param name="rounding"></param>
        public Money(double value, Currency currency, MidpointRounding rounding = MidpointRounding.ToEven)
            : this(rounding)
        {
            Currency = currency;
            Fractional = (long)Math.Round((value * currency.SubUnitToUnit), rounding);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cents"></param>
        /// <param name="currency"></param>
        /// <param name="rounding"></param>
        public Money(int cents, Currency currency, MidpointRounding rounding = MidpointRounding.ToEven)
            : this(rounding)
        {
            Currency = currency;
            Fractional = cents;
        }

        #endregion

        #region Methods

        //TODO: Move to Arithmetic.cs?
        public bool Positive => Fractional > 0;
        public bool Negative => Fractional < 0;


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

        #endregion
    }
}
