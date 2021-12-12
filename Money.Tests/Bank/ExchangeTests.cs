using Xunit;

namespace Money.Tests.Bank
{
    public class ExchangeTests
    {
        [Fact]
        public void ShouldExchangeCurrencies()
        {

            Money.Bank.AddRate(Currency.USD, Currency.CAD, 1.24515);
            Money.Bank.AddRate(Currency.CAD, Currency.USD, 0.803115);

            var usd = Money.FromAmount(100, Currency.USD);
            var cad = Money.FromAmount(100, Currency.CAD);

            //.Exchange(Currency.CAD);  //# => new Money(124, Currency.CAD)
            //.Exchange(Currency.USD); //# => new Money(80, Currency.USD)

            var expected = new Money(124, Currency.CAD);
            var actual = usd.Exchange(Currency.CAD);

            Assert.Equal(expected.ToString(), actual.ToString());
            //Assert.Equal(new Money(80, Currency.USD), cad.Exchange(Currency.USD));
        }
    }
}
