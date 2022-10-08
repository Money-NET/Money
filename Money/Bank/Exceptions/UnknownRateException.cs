namespace Money.Bank.Exceptions
{
    /// <summary>
    /// Raised when the bank doesn't know about the conversion rate
    /// for specified currencies.
    /// </summary>
    public class UnknownRateException : BankException
    {
        public UnknownRateException(string message)
            : base(message)
        {
        }

        public UnknownRateException(Currency from, Currency to)
            : base($"No rate found for exchanging of currencies: #{from} (#{from.Code}) to #{to} (#{to.Code})")
        {
        }
    }
}
