using System;

namespace Money.Exceptions
{
    /// <summary>
    /// Thrown when an unknown currency is requested.
    /// </summary>
    public class UnknownCurrencyException : ArgumentOutOfRangeException
    {
        public UnknownCurrencyException(string currency)
            : base($"Unknown currency {currency}")
        {
        }

        public UnknownCurrencyException(int number)
            : base($"Unknown currency {number}")
        {
        }
    }
}
