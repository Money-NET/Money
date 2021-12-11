using Money.Formatting;
using Xunit;

namespace Money.Tests
{
    public class FormatterTests
    {
        [Fact]
        public void ShouldFormatCurrencies()
        {
            // Brazilian Real
            Assert.Equal("R$1,000.00", new Money(1000.00, Currency.BRL).ToString());

            // Dollars
            Assert.Equal("$1,000.00", new Money(1000.00, Currency.AUD).ToString());
            Assert.Equal("$1,000.00", new Money(1000.00, Currency.CAD).ToString());
            //Assert.Equal("$1,000.00", new Money(1000.00, Currency.NZD).ToString());
            Assert.Equal("$1,000.00", new Money(1000.00, Currency.USD).ToString());
            //Assert.Equal("$1,000.00", new Money(1000.00, Currency.ZWD).ToString());

            // Euro
            Assert.Equal("€1,000.00", new Money(1000.00, Currency.EUR).ToString());

            // Kronor
            Assert.Equal("1 000,00 Kč", new Money(1000.00, Currency.CZK).ToString());
            Assert.Equal("1.000,00 kr.", new Money(1000.00, Currency.DKK).ToString());
            Assert.Equal("1 000,00 kr", new Money(1000.00, Currency.SEK).ToString());

            // Pounds
            Assert.Equal("£1,000.00", new Money(1000.00, Currency.GBP).ToString());

            // Rupees
            Assert.Equal("₹1,000.00", new Money(1000.00, Currency.INR).ToString());
            //Assert.Equal("1,000.00 ₨", new Money(1000.00, Currency.LKR).ToString());
            //Assert.Equal("Rs.1,000.00", new Money(1000.00, Currency.NPR).ToString());
            //Assert.Equal("1,000.00 ₨", new Money(1000.00, Currency.SCR).ToString());

            // Yen
            Assert.Equal("¥1,000.00", new Money(1000.00, Currency.CNY).ToString());
            //Assert.Equal("¥1,000.00", new Money(1000.00, Currency.JPY).ToString());

            // Other
            //Assert.Equal("₵1,000.00", new Money(1000.00, Currency.GHC).ToString());
        }

        [Fact]
        public void ShouldInsertCommasIfAmountIsSufficientlyLarge()
        {
            Assert.Equal("$1,000,000,000", new Money(1_000_000_000.12, Currency.USD).ToString(new Rules(noCents: true)));
            Assert.Equal("$1,000,000,000.12", new Money(1_000_000_000.12, Currency.USD).ToString());
        }

        [Fact]
        public void ShouldUseCorrectThousandsSeparator()
        {
            var usd = new Money(25000000, Currency.USD);
            Assert.Equal(".", usd.Currency.Format.CurrencyDecimalSeparator);
            Assert.Equal(",", usd.Currency.Format.CurrencyGroupSeparator);
            Assert.Equal("$250,000", usd.ToString());


            var sek = new Money(25000000, Currency.SEK);
            Assert.Equal(",", sek.Currency.Format.CurrencyDecimalSeparator);
            Assert.Equal(" ", sek.Currency.Format.CurrencyGroupSeparator);
            Assert.Equal("250 000 kr", sek.ToString());
        }

        //[Fact]
        //public void ShouldUseCorrectThousandsSeparator()
        //{
        //    var usd = new Money(25000000, Currency.USD);
        //    Assert.Equal(".", usd.Currency.Format.CurrencyDecimalSeparator);
        //    Assert.Equal(",", usd.Currency.Format.CurrencyGroupSeparator);
        //    Assert.Equal("$250,000", usd.ToString());


        //    var sek = new Money(25000000, Currency.SEK);
        //    Assert.Equal(",", sek.Currency.Format.CurrencyDecimalSeparator);
        //    Assert.Equal(" ", sek.Currency.Format.CurrencyGroupSeparator);
        //    Assert.Equal("250 000 kr", sek.ToString());
        //}
    }
}
