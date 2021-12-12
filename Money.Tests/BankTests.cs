using System.Linq;
using Xunit;

namespace Money.Tests
{
    public class BankTests
    {
        [Fact]
        public void ShouldOnlyStoreOneExchangeRate()
        {
            Money.Bank.AddRate(Currency.USD, Currency.CAD, 1.24515);
            Money.Bank.AddRate(Currency.CAD, Currency.USD, 0.803115);
            Money.Bank.AddRate(Currency.CAD, Currency.USD, 0.803115);

            Assert.Single(Money.Bank.Rates.Where(x => x.Key == "USD_CAD"));
            Assert.Single(Money.Bank.Rates.Where(x => x.Key == "CAD_USD"));
        }
    }
}
