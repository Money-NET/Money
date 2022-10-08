namespace Money.Bank.Exceptions
{
    /// <summary>
    /// The lowest Money.Bank error class.
    /// All Money.Bank exception should inherit from it.
    /// </summary>
    public class BankException : System.Exception
    {
        public BankException(string message)
            : base(message)
        {
        }
    }
}
