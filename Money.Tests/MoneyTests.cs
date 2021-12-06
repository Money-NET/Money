using System.Linq;
using Money.Bank;
using Xunit;

namespace Money.Tests
{
    public class MoneyTests
    {

        [Fact]
        public void ShouldCreateMoneyObject()
        {
            var sek = new Money(1000, Currency.SEK);
            Assert.Equal(Currency.SEK, sek.Currency);
            Assert.Equal(1000, sek.Centesimal);

            var usd = new Money(49.99, Currency.USD);
            Assert.Equal(Currency.USD, usd.Currency);
            Assert.Equal(4999, usd.Centesimal);
        }

        [Fact]
        public void ShouldAddRateOnBank()
        {
            var money = new Money(1000, Currency.SEK);
            Assert.Equal(Currency.SEK, money.Currency);
            Assert.Equal(typeof(VariableExchange), money.Bank.GetType());

            money.Bank.AddRate(Currency.SEK, Currency.USD, 0.109133);
            money.Bank.AddRate(Currency.USD, Currency.SEK, 9.16479);
            Assert.Equal(2, money.Bank.GetRates().Count());

            var rate1 = money.Bank.GetRate(Currency.SEK, Currency.USD);
            Assert.Equal(rate1.From, Currency.SEK);
            Assert.Equal(rate1.To, Currency.USD);
            Assert.Equal((decimal)0.109133, rate1.Value);

            var rate2 = money.Bank.GetRate(Currency.USD, Currency.SEK);
            Assert.Equal(rate2.From, Currency.USD);
            Assert.Equal(rate2.To, Currency.SEK);
            Assert.Equal((decimal)9.16479, rate2.Value);
        }
    }
}
