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
        private IBank _bank;

        public Money()
        {
            _bank = new Bank.VariableExchange();
        }


        #region Bank

        public IBank Bank => _bank;

        #endregion

        #region Methods

        public Money SetBank(IBank bank)
        {
            _bank = bank;

            return this;
        }
        #endregion
    }
}
