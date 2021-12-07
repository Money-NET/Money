using System;
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
            Assert.IsType<Currency>(sek.Currency);
            Assert.Equal(Currency.SEK, sek.Currency);
            Assert.Equal(1000, sek.Fractional);

            var usd = new Money(49.99, Currency.USD);
            Assert.IsType<Currency>(usd.Currency);
            Assert.Equal(Currency.USD, usd.Currency);
            Assert.Equal(4999, usd.Fractional);
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

        [Fact]
        public void ShouldReturnAmountInFractionalUnit()
        {
            var m1 = new Money(100, Currency.USD);
            Assert.Equal(100, m1.Fractional);

            var m2 = new Money(49.00, Currency.USD);
            Assert.Equal(4900, m2.Fractional);

            var m3 = new Money(49.99, Currency.USD);
            Assert.Equal(4999, m3.Fractional);
        }

        [Fact]
        public void ShouldChangeRoundingMode()
        {
            var m1 = new Money(19.50, Currency.USD);
            Assert.Equal(1950, m1.Fractional);

            var m2 = new Money(29.99, Currency.USD, MidpointRounding.AwayFromZero);
            Assert.Equal(2999, m2.Fractional);

            var m3 = new Money(2999, Currency.USD, MidpointRounding.AwayFromZero);
            Assert.Equal(2999, m3.Fractional);
        }

        [Fact]
        public void ShouldRoundToNearestPossibleCashValue()
        {
            var money = new Money(2350, Currency.AED);
            Assert.Equal(2350, money.RoundToNearestCashValue());

            money = new Money(-2350, Currency.AED);
            Assert.Equal(-2350, money.RoundToNearestCashValue());

            money = new Money(2213, Currency.AED);
            Assert.Equal(2225, money.RoundToNearestCashValue());

            money = new Money(-2213, Currency.AED);
            Assert.Equal(-2225, money.RoundToNearestCashValue());

            money = new Money(2212, Currency.AED);
            Assert.Equal(2200, money.RoundToNearestCashValue());

            money = new Money(-2212, Currency.AED);
            Assert.Equal(-2200, money.RoundToNearestCashValue());


            money = new Money(178, Currency.CHF);
            Assert.Equal(180, money.RoundToNearestCashValue());

            money = new Money(-178, Currency.CHF);
            Assert.Equal(-180, money.RoundToNearestCashValue());

            money = new Money(177, Currency.CHF);
            Assert.Equal(175, money.RoundToNearestCashValue());

            money = new Money(-177, Currency.CHF);
            Assert.Equal(-175, money.RoundToNearestCashValue());


            money = new Money(299, Currency.USD);
            Assert.Equal(299, money.RoundToNearestCashValue());

            money = new Money(-299, Currency.USD);
            Assert.Equal(-299, money.RoundToNearestCashValue());

            money = new Money(300, Currency.USD);
            Assert.Equal(300, money.RoundToNearestCashValue());

            money = new Money(-300, Currency.USD);
            Assert.Equal(-300, money.RoundToNearestCashValue());

            money = new Money(301, Currency.USD);
            Assert.Equal(301, money.RoundToNearestCashValue());

            money = new Money(-301, Currency.USD);
            Assert.Equal(-301, money.RoundToNearestCashValue());
        }

        [Fact]
        public void ShouldExchangeCurrency()
        {
        }
    }
}
