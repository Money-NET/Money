using System;
using Money.Bank.Interfaces;

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
        public int Fractional;
        public MidpointRounding Rounding = MidpointRounding.ToEven;

        public Money(MidpointRounding rounding = MidpointRounding.ToEven)
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
            Fractional = (int)Math.Round((value * currency.SubUnitToUnit), rounding);
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
            Fractional = (int)Math.Round((value * currency.SubUnitToUnit), rounding);
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


        #region Bank

        #endregion

        #region Methods
        /// <summary>
        /// Round a given amount of money to the nearest possible amount in cash value. For
        /// example, in Swiss franc (CHF), the smallest possible amount of cash value is
        /// CHF 0.05. Therefore, this method rounds CHF 0.07 to CHF 0.05, and CHF 0.08 to
        /// CHF 0.10.
        /// </summary>
        /// <returns></returns>
        public decimal RoundToNearestCashValue()
        {
            //TODO: Is this needed i .NET?
            //if (Currency.SmallestDenomination == null)
            //    throw new UndefinedSmallestDenominationException(Currency);
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
    }
}
