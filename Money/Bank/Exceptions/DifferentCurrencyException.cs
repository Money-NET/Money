namespace Money.Bank.Exceptions
{
    public class DifferentCurrencyException : BankException
    {
        public DifferentCurrencyException(string message)
            : base(message)
        {
        }

        public DifferentCurrencyException(Currency from, Currency to)
            : base($"No exchanging of currencies allowed: #{from} (#{from.Code}) to #{to} (#{to.Code})")
        {
        }
    }
}
