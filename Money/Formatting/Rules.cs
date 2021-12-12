using Money.Enums;

namespace Money.Formatting
{
    public class Rules
    {
        public bool? Disambiguate { get; set; }
        public bool? DropTrailingZeros { get; set; }
        public bool? RoundedInfinitePrecision { get; set; }
        public NegativePosition? NegativePosition { get; set; }
        public bool? NoCents { get; set; }
        public bool? NoCentsIfWhole { get; set; }
        public PositivePosition? PositivePosition { get; set; }
        public bool? ShowPositiveSign { get; set; }
        public bool? ShowSymbol { get; set; }

        public Rules(
            bool? disambiguate = null,
            bool? dropTrailingZeros = null,
            bool? roundedInfinitePrecision = null,
            NegativePosition? negativePosition = null,
            bool? noCents = null,
            bool? noCentsIfWhole = null,
            PositivePosition? positivePosition = null,
            bool? showPositiveSign = null,
            bool? showSymbol = null)
        {
            Disambiguate = disambiguate;
            DropTrailingZeros = dropTrailingZeros;
            RoundedInfinitePrecision = roundedInfinitePrecision;
            NegativePosition = negativePosition;
            NoCents = noCents;
            NoCentsIfWhole = noCentsIfWhole;
            PositivePosition = positivePosition;
            ShowPositiveSign = showPositiveSign;
            ShowSymbol = showSymbol;
        }
    }
}
