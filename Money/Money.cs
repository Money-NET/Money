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
        public int Centesimal;

        public Money()
        {
            Bank = new Bank.VariableExchange();
        }

        /// <summary>
        /// Creates a new Money object of value given in the +unit+ of the given
        /// +currency+.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currency"></param>
        public Money(decimal value, Currency currency)
        {
            Bank = new Bank.VariableExchange();
            Currency = currency;
            Centesimal = (int)Math.Round((value * currency.CentesimalConversion), MidpointRounding.ToEven);
        }


        /// <summary>
        /// Creates a new Money object of value given in the +unit+ of the given
        /// +currency+.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currency"></param>
        public Money(double value, Currency currency)
        {
            Bank = new Bank.VariableExchange();
            Currency = currency;
            Centesimal = (int)Math.Round((value * currency.CentesimalConversion), MidpointRounding.ToEven);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cents"></param>
        /// <param name="currency"></param>
        public Money(int cents, Currency currency)
        {
            Bank = new Bank.VariableExchange();
            Currency = currency;
            Centesimal = cents;
        }


        #region Bank

        #endregion

        #region Methods

        public Money SetBank(IBank bank)
        {
            Bank = bank;

            return this;
        }
        #endregion
    }
}
