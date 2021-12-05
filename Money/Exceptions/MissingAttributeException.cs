using System;

namespace Money.Exceptions
{
    /// <summary>
    /// Thrown when a Currency has been registered without all the attributes
    /// which are required for the current action.
    /// </summary>
    public class MissingAttributeException : ArgumentException
    {
        public MissingAttributeException(string method, string currency, string attribute)
            :base($"Can't call Currency.{method} - currency '{currency}' is missing the attribute '{attribute}'")
        {
        }
    }
}
