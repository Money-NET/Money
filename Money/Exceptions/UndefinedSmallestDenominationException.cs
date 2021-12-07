using System;

namespace Money.Exceptions
{
    public class UndefinedSmallestDenominationException : Exception
    {
        public UndefinedSmallestDenominationException(Currency currency)
            : base($"Smallest denomination of this currency is not defined for currency ({currency.Code})")
        {
        }
    }
}
