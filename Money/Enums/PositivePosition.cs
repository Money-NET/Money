using System.ComponentModel;

namespace Money.Enums
{
    /// <summary>
    /// The CurrencyPositivePattern property is used with the "C" standard format string
    /// to define pattern of positive currency values. For more information,
    /// see Standard Numeric Format Strings.
    ///
    /// This property has one of the values in the following table. The symbol "$" is
    /// the CurrencySymbol and n is a number.
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.currencypositivepattern?view=net-6.0#remarks
    /// </summary>
    public enum PositivePosition
    {
        [Description("$n")]
        Before = 0,
        [Description("n$")]
        After = 1,
        [Description("$ n")]
        BeforeWithSpace = 2,
        [Description("n $")]
        AfterWithSpace = 3
    }
}
