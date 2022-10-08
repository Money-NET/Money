using Money.Bank.Exceptions;
using Xunit;

namespace Money.Tests.Bank
{
    public class ExchangeTests
    {
        [Fact]
        public void ShouldThrowExceptionForCurrenciesWithNoRate()
        {
            var usd = Money.FromAmount(100, Currency.USD);

            Assert.Throws<UnknownRateException>(() => usd.Exchange(Currency.CAD));
        }

        [Fact]
        public void ShouldExchangeCurrencies()
        {
            Money.Bank.AddRate(Currency.USD, Currency.CAD, 1.24515);
            Money.Bank.AddRate(Currency.CAD, Currency.USD, 0.803115);

            var usd = Money.FromAmount(100, Currency.USD);
            var cad = Money.FromAmount(100, Currency.CAD);

            var expected = Money.FromAmount(124.51, Currency.CAD);
            var actual = usd.Exchange(Currency.CAD);
            Assert.Equal(expected.ToString(), actual.ToString());

            expected = Money.FromAmount(80.31, Currency.CAD);
            actual = cad.Exchange(Currency.USD);
            Assert.Equal(expected.ToString(), actual.ToString());
        }
    }
}
