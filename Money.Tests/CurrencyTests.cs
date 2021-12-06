using Xunit;

namespace Money.Tests
{
    public class CurrencyTests
    {
        [Fact]
        public void ShouldBeComparable()
        {
            Assert.True(Currency.SEK == Currency.SEK);
            Assert.False(Currency.SEK == Currency.USD);

            Assert.True(Currency.SEK != Currency.USD);
            Assert.False(Currency.SEK != Currency.SEK);

            Assert.True(Currency.SEK.Equals(Currency.SEK));
            Assert.False(Currency.SEK.Equals(Currency.USD));
        }

        [Fact]
        public void ShouldReturnCodeOnToString()
        {
            Assert.Equal("SEK", Currency.SEK.ToString());
        }

        #region Currencies
        [Fact]
        public void AED()
        {
            const string symbol = "د.إ.‏";
            var currency = Currency.AED;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("AED", currency.Code);
            Assert.Equal("United Arab Emirates Dirham", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "DH", "Dhs" }, currency.Symbols);
            Assert.Equal("Fils", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(784, currency.Number);
            Assert.Equal(25, currency.SmallestDenomination);
        }

        [Fact]
        public void AFN()
        {
            const string symbol = "؋";
            var currency = Currency.AFN;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("AFN", currency.Code);
            Assert.Equal("Afghan Afghani", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "Af", "Afs" }, currency.Symbols);
            Assert.Equal("Pul", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(".", currency.ThousandsSeparator);
            Assert.Equal(971, currency.Number);
            Assert.Equal(100, currency.SmallestDenomination);
        }

        [Fact]
        public void ALL()
        {
            const string symbol = "Lekë";
            var currency = Currency.ALL;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("ALL", currency.Code);
            Assert.Equal("Albanian Lek", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "Lek" }, currency.Symbols);
            Assert.Equal("Qintar", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(" ", currency.ThousandsSeparator);
            Assert.Equal(008, currency.Number);
            Assert.Equal(100, currency.SmallestDenomination);
        }

        [Fact]
        public void AMD()
        {
            const string symbol = "֏";
            var currency = Currency.AMD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("AMD", currency.Code);
            Assert.Equal("Armenian Dram", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "dram" }, currency.Symbols);
            Assert.Equal("Luma", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(051, currency.Number);
            Assert.Equal(10, currency.SmallestDenomination);
        }

        [Fact]
        public void BHD()
        {
            const string symbol = "د.ب.‏";
            var currency = Currency.BHD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("BHD", currency.Code);
            Assert.Equal("Bahraini Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "BD" }, currency.Symbols);
            Assert.Equal("Fils", currency.Centesimal);
            Assert.Equal(1000, currency.CentesimalConversion);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(048, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);
        }

        [Fact]
        public void DZD()
        {
            const string symbol = "د.ج.‏";
            var currency = Currency.DZD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("DZD", currency.Code);
            Assert.Equal("Algerian Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "DA" }, currency.Symbols);
            Assert.Equal("Centime", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(012, currency.Number);
            Assert.Equal(100, currency.SmallestDenomination);
        }

        [Fact]
        public void EGP()
        {
            const string symbol = "ج.م.‏";
            var currency = Currency.EGP;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("EGP", currency.Code);
            Assert.Equal("Egyptian Pound", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "LE", "E£", "L.E." }, currency.Symbols);
            Assert.Equal("Piastre", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(818, currency.Number);
            Assert.Equal(25, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void ETB()
        {
            const string symbol = "ብር";
            var currency = Currency.ETB;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("ETB", currency.Code);
            Assert.Equal("Ethiopian Birr", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol }, currency.Symbols);
            Assert.Equal("Santim", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(230, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void IQD()
        {
            const string symbol = "د.ع.‏";
            var currency = Currency.IQD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("IQD", currency.Code);
            Assert.Equal("Iraqi Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol }, currency.Symbols);
            Assert.Equal("Fils", currency.Centesimal);
            Assert.Equal(1000, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(368, currency.Number);
            Assert.Equal(50000, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(3, currency.Exponent);
        }

        [Fact]
        public void JOD()
        {
            const string symbol = "د.ا.‏";
            var currency = Currency.JOD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("JOD", currency.Code);
            Assert.Equal("Jordanian Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "JD" }, currency.Symbols);
            Assert.Equal("Fils", currency.Centesimal);
            Assert.Equal(1000, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(400, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(3, currency.Exponent);
        }

        [Fact]
        public void KWD()
        {
            const string symbol = "د.ك.‏";
            var currency = Currency.KWD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("KWD", currency.Code);
            Assert.Equal("Kuwaiti Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "K.D." }, currency.Symbols);
            Assert.Equal("Fils", currency.Centesimal);
            Assert.Equal(1000, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(414, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(3, currency.Exponent);
        }

        [Fact]
        public void LBP()
        {
            const string symbol = "ل.ل.‏";
            var currency = Currency.LBP;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("LBP", currency.Code);
            Assert.Equal("Lebanese Pound", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "£", "L£" }, currency.Symbols);
            Assert.Equal("Piastre", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(422, currency.Number);
            Assert.Equal(25000, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void SEK()
        {
            const string symbol = "kr";
            var currency = Currency.SEK;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("SEK", currency.Code);
            Assert.Equal("Swedish Krona", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, ":-" }, currency.Symbols);
            Assert.Equal("Öre", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(" ", currency.ThousandsSeparator);
            Assert.Equal(752, currency.Number);
            Assert.Equal(100, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void USD()
        {
            const string symbol = "$";
            var currency = Currency.USD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("USD", currency.Code);
            Assert.Equal("US Dollar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "US$" }, currency.Symbols);
            Assert.Equal("Cent", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(840, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void ZAR()
        {
            const string symbol = "R";
            var currency = Currency.ZAR;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("ZAR", currency.Code);
            Assert.Equal("South African Rand", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol }, currency.Symbols);
            Assert.Equal("Cent", currency.Centesimal);
            Assert.Equal(100, currency.CentesimalConversion);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(" ", currency.ThousandsSeparator);
            Assert.Equal(710, currency.Number);
            Assert.Equal(10, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }
        #endregion
    }
}
