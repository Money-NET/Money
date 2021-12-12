using Money.Enums;
using Xunit;

namespace Money.Tests
{
    public class FormatterTests
    {
        [Fact]
        public void ShouldFormat()
        {
            Assert.Equal("$1.00", new Money(100, Currency.USD).ToString());
            Assert.Equal("£1.00", new Money(100, Currency.GBP).ToString());
            Assert.Equal("€1,00", new Money(100, Currency.EUR).ToString());

            Assert.Equal("1.00", new Money(100, Currency.USD).ToString(showSymbol: false));
            Assert.Equal("1.00", new Money(100, Currency.GBP).ToString(showSymbol: false));
            Assert.Equal("1,00", new Money(100, Currency.EUR).ToString(showSymbol: false));
        }

        [Fact]
        public void ShouldFormatCurrencies()
        {
            // Brazilian Real
            Assert.Equal("R$1.000,00", new Money(100000, Currency.BRL).ToString());

            // Dollars
            Assert.Equal("$1,000.00", new Money(100000, Currency.AUD).ToString());
            Assert.Equal("$1,000.00", new Money(100000, Currency.CAD).ToString());
            //Assert.Equal("$1,000.00", new Money(1000.00, Currency.NZD).ToString());
            Assert.Equal("$1,000.00", new Money(100000, Currency.USD).ToString());
            //Assert.Equal("$1,000.00", new Money(1000.00, Currency.ZWD).ToString());

            // Euro
            Assert.Equal("€1.000,00", new Money(100000, Currency.EUR).ToString());

            // Kronor
            Assert.Equal("1 000,00 Kč", new Money(100000, Currency.CZK).ToString());
            Assert.Equal("1.000,00 kr.", new Money(100000, Currency.DKK).ToString());
            Assert.Equal("1 000,00 kr", new Money(100000, Currency.SEK).ToString());

            // Pounds
            Assert.Equal("£1,000.00", new Money(100000, Currency.GBP).ToString());

            // Rupees
            Assert.Equal("₹1,000.00", new Money(100000, Currency.INR).ToString());
            //Assert.Equal("1,000.00 ₨", new Money(1000.00, Currency.LKR).ToString());
            //Assert.Equal("Rs.1,000.00", new Money(1000.00, Currency.NPR).ToString());
            //Assert.Equal("1,000.00 ₨", new Money(1000.00, Currency.SCR).ToString());

            // Yen
            Assert.Equal("¥1,000.00", new Money(100000, Currency.CNY).ToString());
            //Assert.Equal("¥1,000.00", new Money(1000.00, Currency.JPY).ToString());

            // Other
            //Assert.Equal("₵1,000.00", new Money(1000.00, Currency.GHC).ToString());
        }

        [Fact]
        public void ShouldInsertCommasIfAmountIsSufficientlyLarge()
        {
            Assert.Equal("$1,000,000,000", new Money(1_000_000_000_12, Currency.USD).ToString(noCents: true));
            Assert.Equal("$1,000,000,000.12", new Money(1_000_000_000_12, Currency.USD).ToString());
        }

        [Fact]
        public void ShouldUseCorrectThousandsSeparator()
        {
            var usd = new Money(25000000, Currency.USD);
            Assert.Equal(".", usd.Currency.Format.CurrencyDecimalSeparator);
            Assert.Equal(",", usd.Currency.Format.CurrencyGroupSeparator);
            Assert.Equal("$250,000.00", usd.ToString());

            var sek = new Money(25000000, Currency.SEK);
            Assert.Equal(",", sek.Currency.Format.CurrencyDecimalSeparator);
            Assert.Equal(" ", sek.Currency.Format.CurrencyGroupSeparator);
            Assert.Equal("250 000,00 kr", sek.ToString());

            Assert.Equal("€1.234.567,12", new Money(1_234_567_12, Currency.EUR).ToString());
            Assert.Equal("€1.234.567", new Money(1_234_567_12, Currency.EUR).ToString(noCents: true));
        }

        [Fact]
        public void ShouldHandleNegativePositioning()
        {
            Assert.Equal("-£1.00", new Money(-100, Currency.GBP).ToString());
            Assert.Equal("(£1.00)", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Zero));
            Assert.Equal("-£1.00", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.One));
            Assert.Equal("£-1.00", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Two));
            Assert.Equal("£1.00-", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Three));
            Assert.Equal("(1.00£)", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Four));
            Assert.Equal("-1.00£", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Five));
            Assert.Equal("1.00-£", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Six));
            Assert.Equal("1.00£-", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Seven));
            Assert.Equal("-1.00 £", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Eight));
            Assert.Equal("-£ 1.00", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Nine));
            Assert.Equal("1.00 £-", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Ten));
            Assert.Equal("£ 1.00-", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Eleven));
            Assert.Equal("£ -1.00", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Twelve));
            Assert.Equal("1.00- £", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Thirteen));
            Assert.Equal("(£ 1.00)", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Fourteen));
            Assert.Equal("(1.00 £)", new Money(-100, Currency.GBP).ToString(negativePosition: NegativePosition.Fifteen));


            Assert.Equal("-1,00 kr", new Money(-100, Currency.SEK).ToString());
            Assert.Equal("(kr1,00)", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Zero));
            Assert.Equal("-kr1,00", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.One));
            Assert.Equal("kr-1,00", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Two));
            Assert.Equal("kr1,00-", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Three));
            Assert.Equal("(1,00kr)", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Four));
            Assert.Equal("-1,00kr", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Five));
            Assert.Equal("1,00-kr", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Six));
            Assert.Equal("1,00kr-", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Seven));
            Assert.Equal("-1,00 kr", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Eight));
            Assert.Equal("-kr 1,00", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Nine));
            Assert.Equal("1,00 kr-", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Ten));
            Assert.Equal("kr 1,00-", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Eleven));
            Assert.Equal("kr -1,00", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Twelve));
            Assert.Equal("1,00- kr", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Thirteen));
            Assert.Equal("(kr 1,00)", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Fourteen));
            Assert.Equal("(1,00 kr)", new Money(-100, Currency.SEK).ToString(negativePosition: NegativePosition.Fifteen));
        }

        [Fact]
        public void ShouldHandlePositivePositioning()
        {
            Assert.Equal("1.00$", new Money(100, Currency.USD).ToString(positivePosition: PositivePosition.After));
            Assert.Equal("1.00 $", new Money(100, Currency.USD).ToString(positivePosition: PositivePosition.AfterWithSpace));

            Assert.Equal("kr1,00", new Money(100, Currency.SEK).ToString(positivePosition: PositivePosition.Before));
            Assert.Equal("kr 1,00", new Money(100, Currency.SEK).ToString(positivePosition: PositivePosition.BeforeWithSpace));
        }

        [Fact]
        public void ShouldHandleDisambiguateSymbols()
        {
            Assert.Equal("C$1,999.98", new Money(1999_98, Currency.CAD).ToString(disambiguate: true));
            Assert.Equal("1,999.98", new Money(1999_98, Currency.CAD).ToString(disambiguate: true, showSymbol: false));

            //Assert.Equal("0.00199998 ₿CH", new Money(1999_98, Currency.BCH).ToString(disambiguate: true));
            //Assert.Equal("0.00199998", new Money(1999_98, Currency.BCH).ToString(disambiguate: true, showSymbol: false));

            Assert.Equal("1.999,98 DKK", new Money(1999_98, Currency.DKK).ToString(disambiguate: true));
            Assert.Equal("1.999,98", new Money(1999_98, Currency.DKK).ToString(disambiguate: true, showSymbol: false));

            //Assert.Equal("1.999,98 NOK", new Money(1999_98, Currency.NOK).ToString(disambiguate: true));
            //Assert.Equal("1.999,98", new Money(1999_98, Currency.NOK).ToString(disambiguate: true, showSymbol: false));

            Assert.Equal("1 999,98 SEK", new Money(1999_98, Currency.SEK).ToString(disambiguate: true));
            Assert.Equal("1 999,98", new Money(1999_98, Currency.SEK).ToString(disambiguate: true, showSymbol: false));

            Assert.Equal("US$1,999.98", new Money(1999_98, Currency.USD).ToString(disambiguate: true));
            Assert.Equal("1,999.98", new Money(1999_98, Currency.USD).ToString(disambiguate: true, showSymbol: false));
        }
    }
}
