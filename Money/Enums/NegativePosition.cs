using System.ComponentModel;

namespace Money.Enums
{
    /// <summary>
    /// The CurrencyNegativePattern property is used with the "C" standard format string
    /// to define the pattern of negative currency values. For more information, see Standard
    /// Numeric Format Strings.
    ///
    /// This property has one of the values in the following table. The symbol "$" is the
    /// CurrencySymbol, the symbol "-" is the NegativeSign, and n is a number.
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.currencynegativepattern?view=net-6.0#remarks
    /// </summary>
    public enum NegativePosition
    {
        [Description("($n)")]
        Zero = 0,
        [Description("-$n")]
        One = 1,
        [Description("$-n")]
        Two = 2,
        [Description("$n-")]
        Three = 3,
        [Description("(n$)")]
        Four = 4,
        [Description("-n$")]
        Five = 5,
        [Description("n-$")]
        Six = 6,
        [Description("n$-")]
        Seven = 7,
        [Description("-n $")]
        Eight = 8,
        [Description("-$ n")]
        Nine = 9,
        [Description("n $-")]
        Ten = 10,
        [Description("$ n-")]
        Eleven = 11,
        [Description("$ -n")]
        Twelve = 12,
        [Description("n- $")]
        Thirteen = 13,
        [Description("($ n)")]
        Fourteen = 14,
        [Description("(n $)")]
        Fifteen = 15
    }
}
