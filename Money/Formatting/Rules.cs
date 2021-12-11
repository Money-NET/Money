namespace Money.Formatting
{
    public class Rules
    {
        public bool Disambiguate { get; }
        public bool DropTrailingZeros { get; }
        public bool RoundedInfinitePrecision { get;  }
        public bool NoCents { get; }
        public bool NoCentsIfWhole { get; }
        public bool SignBeforeSymbol { get; }
        public bool ShowPositiveSign { get; }
        public bool ShowSymbol { get; }
        public bool WithCurrency { get; }

        public Rules(
            bool disambiguate = false,
            bool dropTrailingZeros = false,
            bool roundedInfinitePrecision = false,
            bool noCents = false,
            bool noCentsIfWhole = false,
            bool signBeforeSymbol = false,
            bool showPositiveSign = false,
            bool showSymbol = true,
            bool withCurrency = true)
        {
            Disambiguate = disambiguate;
            DropTrailingZeros = dropTrailingZeros;
            RoundedInfinitePrecision = roundedInfinitePrecision;
            NoCents = noCents;
            NoCentsIfWhole = noCentsIfWhole;
            SignBeforeSymbol = signBeforeSymbol;
            ShowPositiveSign = showPositiveSign;
            ShowSymbol = showSymbol;
            WithCurrency = withCurrency;
        }
    }
}
