using Xunit;

namespace Money.Tests
{
    public class FormatterTests
    {
        [Fact]
        public void ShouldUseCorrectThousandsSeparator()
        {
            var usd = new Money(19.99, Currency.USD);
            Assert.Equal(".", usd.Currency.DecimalMark);
            Assert.Equal(",", usd.Currency.ThousandsSeparator);
            Assert.Equal("$19.99", usd.ToString());

            var sek = new Money(199.95, Currency.SEK);
            Assert.Equal(".", sek.Currency.DecimalMark);
            Assert.Equal(",", sek.Currency.ThousandsSeparator);
        }
    }
}
