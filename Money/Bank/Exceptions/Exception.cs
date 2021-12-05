namespace Money.Bank.Exceptions
{
    /// <summary>
    /// The lowest Money.Bank error class.
    /// All Money.Bank exception should inherit from it.
    /// </summary>
    public class Exception : System.Exception
    {
        public Exception(string message)
            : base(message)
        {
        }
    }
}
