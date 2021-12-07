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
            Assert.Equal("Fils", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(784, currency.Number);
            Assert.Equal(25, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
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
            Assert.Equal("Pul", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(971, currency.Number);
            Assert.Equal(100, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
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
            Assert.Equal("Qintar", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(008, currency.Number);
            Assert.Equal(100, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
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
            Assert.Equal("Luma", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(051, currency.Number);
            Assert.Equal(10, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void ANG()
        {
            const string symbol = "ƒ";
            var currency = Currency.ANG;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("ANG", currency.Code);
            Assert.Equal("Netherlands Antillean Gulden", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "NAƒ", "NAf", "f" }, currency.Symbols);
            Assert.Equal("Cent", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(".", currency.ThousandsSeparator);
            Assert.Equal(532, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void AOA()
        {
            const string symbol = "Kz";
            var currency = Currency.AOA;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("AOA", currency.Code);
            Assert.Equal("Angolan Kwanza", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol }, currency.Symbols);
            Assert.Equal("Cêntimo", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(973, currency.Number);
            Assert.Equal(10, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void ARS()
        {
            const string symbol = "$";
            var currency = Currency.ARS;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("ARS", currency.Code);
            Assert.Equal("Argentine Peso", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "$m/n", "m$n" }, currency.Symbols);
            Assert.Equal("$m/n", currency.DisambiguateSymbol);
            Assert.Equal("Centavo", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(".", currency.ThousandsSeparator);
            Assert.Equal(032, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void AUD()
        {
            const string symbol = "$";
            var currency = Currency.AUD;

            Assert.Equal(4, currency.Priority);
            Assert.Equal("AUD", currency.Code);
            Assert.Equal("Australian Dollar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "A$" }, currency.Symbols);
            Assert.Equal("A$", currency.DisambiguateSymbol);
            Assert.Equal("Cent", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(036, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void AWG()
        {
            const string symbol = "ƒ";
            var currency = Currency.AWG;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("AWG", currency.Code);
            Assert.Equal("Aruban Florin", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "Afl" }, currency.Symbols);
            Assert.Equal("Cent", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(533, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void AZN()
        {
            const string symbol = "₼";
            var currency = Currency.AZN;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("AZN", currency.Code);
            Assert.Equal("Azerbaijani Manat", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "m", "man" }, currency.Symbols);
            Assert.Equal("Qəpik", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(944, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void BAM()
        {
            const string symbol = "КМ";
            var currency = Currency.BAM;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("BAM", currency.Code);
            Assert.Equal("Bosnia-Herzegovina Convertible Mark", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "KM" }, currency.Symbols);
            Assert.Equal("Fening", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(977, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void BHD()
        {
            const string symbol = "د.ب";
            var currency = Currency.BHD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("BHD", currency.Code);
            Assert.Equal("Bahraini Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "BD" }, currency.Symbols);
            Assert.Equal("Fils", currency.SubUnit);
            Assert.Equal(1000, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(048, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(3, currency.Exponent);
        }

        [Fact]
        public void BBD()
        {
            const string symbol = "$";
            var currency = Currency.BBD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("BBD", currency.Code);
            Assert.Equal("Barbadian Dollar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "Bds$" }, currency.Symbols);
            Assert.Equal("Bds$", currency.DisambiguateSymbol);
            Assert.Equal("Cent", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(052, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void BDT()
        {
            const string symbol = "৳";
            var currency = Currency.BDT;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("BDT", currency.Code);
            Assert.Equal("Bangladeshi Taka", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "Tk" }, currency.Symbols);
            Assert.Equal("Paisa", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(050, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void BGN()
        {
            const string symbol = "лв.";
            var currency = Currency.BGN;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("BGN", currency.Code);
            Assert.Equal("Bulgarian Lev", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "lev", "leva", "лев", "лева" }, currency.Symbols);
            Assert.Equal("Stotinka", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(975, currency.Number);
            Assert.Equal(1, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void CHF()
        {
            const string symbol = "CHF";
            var currency = Currency.CHF;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("CHF", currency.Code);
            Assert.Equal("Swiss Franc", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "SFr", "Fr" }, currency.Symbols);
            Assert.Equal("Rappen", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u%n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal("’", currency.ThousandsSeparator);
            Assert.Equal(756, currency.Number);
            Assert.Equal(5, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }

        [Fact]
        public void DZD()
        {
            const string symbol = "د.ج";
            var currency = Currency.DZD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("DZD", currency.Code);
            Assert.Equal("Algerian Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "DA" }, currency.Symbols);
            Assert.Equal("Centime", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
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
            const string symbol = "ج.م";
            var currency = Currency.EGP;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("EGP", currency.Code);
            Assert.Equal("Egyptian Pound", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "LE", "E£", "L.E." }, currency.Symbols);
            Assert.Equal("Piastre", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
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
            const string symbol = "Br";
            var currency = Currency.ETB;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("ETB", currency.Code);
            Assert.Equal("Ethiopian Birr", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "ብር" }, currency.Symbols);
            Assert.Equal("Santim", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
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
            const string symbol = "ع.د";
            var currency = Currency.IQD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("IQD", currency.Code);
            Assert.Equal("Iraqi Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol }, currency.Symbols);
            Assert.Equal("Fils", currency.SubUnit);
            Assert.Equal(1000, currency.SubUnitToUnit);
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
            const string symbol = "د.ا";
            var currency = Currency.JOD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("JOD", currency.Code);
            Assert.Equal("Jordanian Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "JD" }, currency.Symbols);
            Assert.Equal("Fils", currency.SubUnit);
            Assert.Equal(1000, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
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
            const string symbol = "د.ك";
            var currency = Currency.KWD;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("KWD", currency.Code);
            Assert.Equal("Kuwaiti Dinar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "K.D." }, currency.Symbols);
            Assert.Equal("Fils", currency.SubUnit);
            Assert.Equal(1000, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
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
            const string symbol = "ل.ل";
            var currency = Currency.LBP;

            Assert.Equal(100, currency.Priority);
            Assert.Equal("LBP", currency.Code);
            Assert.Equal("Lebanese Pound", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "£", "L£" }, currency.Symbols);
            Assert.Equal("Piastre", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
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
            Assert.Equal("Öre", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.False(currency.SymbolFirst);
            Assert.Equal("%n %u", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(",", currency.DecimalMark);
            Assert.Equal(" ", currency.ThousandsSeparator);
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
            Assert.Equal("United States Dollar", currency.Name);
            Assert.Equal(symbol, currency.Symbol);
            Assert.Equal(new[] { symbol, "US$" }, currency.Symbols);
            Assert.Equal("Cent", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
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
            Assert.Equal("Cent", currency.SubUnit);
            Assert.Equal(100, currency.SubUnitToUnit);
            Assert.True(currency.SymbolFirst);
            Assert.Equal("%u %n", currency.Format);
            Assert.Null(currency.HtmlEntity);
            Assert.Equal(".", currency.DecimalMark);
            Assert.Equal(",", currency.ThousandsSeparator);
            Assert.Equal(710, currency.Number);
            Assert.Equal(10, currency.SmallestDenomination);

            Assert.True(currency.IsIso);
            Assert.Equal(2, currency.Exponent);
        }
        #endregion
    }
}
