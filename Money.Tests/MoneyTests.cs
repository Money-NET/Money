using System;
using Money.Bank;
using Xunit;

namespace Money.Tests
{
    public class MoneyTests
    {
        public MoneyTests()
        {
            Money.Bank.AddRate(Currency.SEK, Currency.USD, 0.109133);
            Money.Bank.AddRate(Currency.USD, Currency.SEK, 9.16479);
        }

        [Fact]
        public void ShouldCreateMoney()
        {
            Assert.Equal("$1.00", new Money(100, Currency.USD).ToString());
            Assert.Equal("$1.00", Money.FromCents(100, Currency.USD).ToString());
            Assert.Equal("$1.00", Money.FromAmount(1, Currency.USD).ToString());

            Assert.Equal("$1.99", new Money(199, Currency.USD).ToString());
            Assert.Equal("$1.99", Money.FromCents(199, Currency.USD).ToString());
            Assert.Equal("$1.99", Money.FromAmount(1.99, Currency.USD).ToString());

            Assert.Equal("$5.00", new Money(500, Currency.USD).ToString());
            Assert.Equal("$5.00", Money.FromCents(500, Currency.USD).ToString());
            Assert.Equal("$5.00", Money.FromAmount(5, Currency.USD).ToString());

            Assert.Equal("$29.95", new Money(2995, Currency.USD).ToString());
            Assert.Equal("$29.95", Money.FromCents(2995, Currency.USD).ToString());
            Assert.Equal("$29.95", Money.FromAmount(29.95, Currency.USD).ToString());

            Assert.Equal("$50.00", new Money(5000, Currency.USD).ToString());
            Assert.Equal("$50.00", Money.FromCents(5000, Currency.USD).ToString());
            Assert.Equal("$50.00", Money.FromAmount(50, Currency.USD).ToString());

            //Assert.Equal("$149.95", new Money(14995, Currency.USD).ToString());
            //Assert.Equal("$149.95", Money.FromCents(14995, Currency.USD).ToString());
            //Assert.Equal("$149.95", Money.FromAmount(149.95, Currency.USD).ToString());

            Assert.Equal("$4,995.95", new Money(499595, Currency.USD).ToString());
            Assert.Equal("$4,995.95", Money.FromCents(499595, Currency.USD).ToString());
            Assert.Equal("$4,995.95", Money.FromAmount(4995.95, Currency.USD).ToString());

            Assert.Equal("$14,995.95", new Money(1499595, Currency.USD).ToString());
            Assert.Equal("$14,995.95", Money.FromCents(1499595, Currency.USD).ToString());
            Assert.Equal("$14,995.95", Money.FromAmount(14995.95, Currency.USD).ToString());

            Assert.Equal("$149,995.95", new Money(14999595, Currency.USD).ToString());
            Assert.Equal("$149,995.95", Money.FromCents(14999595, Currency.USD).ToString());
            Assert.Equal("$149,995.95", Money.FromAmount(149995.95, Currency.USD).ToString());

            Assert.Equal("$1,149,995.95", new Money(114999595, Currency.USD).ToString());
            Assert.Equal("$1,149,995.95", Money.FromCents(114999595, Currency.USD).ToString());
            Assert.Equal("$1,149,995.95", Money.FromAmount(1149995.95, Currency.USD).ToString());

            Assert.Equal("$14,299,995.95", new Money(1429999595, Currency.USD).ToString());
            Assert.Equal("$14,299,995.95", Money.FromCents(1429999595, Currency.USD).ToString());
            Assert.Equal("$14,299,995.95", Money.FromAmount(14299995.95, Currency.USD).ToString());

            //Assert.Equal("$149,299,995.95", new Money(14929999595, Currency.USD).ToString());
            //Assert.Equal("$149,299,995.95", Money.FromCents(14929999595, Currency.USD).ToString());
            //Assert.Equal("$149,299,995.95", Money.FromAmount(149299995.95, Currency.USD).ToString());

            Assert.Equal("$1,149,299,995.95", new Money(114929999595, Currency.USD).ToString());
            Assert.Equal("$1,149,299,995.95", Money.FromCents(114929999595, Currency.USD).ToString());
            Assert.Equal("$1,149,299,995.95", Money.FromAmount(1149299995.95, Currency.USD).ToString());
        }

        [Fact]
        public void ShouldHoldCurrencyInformation()
        {
            var currency = new Money(1000, Currency.USD).Currency;

            Assert.Equal("USD", currency.Code);
            Assert.Equal(840, currency.Number);
            Assert.Equal("United States Dollar", currency.Name);
        }

        [Fact]
        public void ShouldCreateMoneyObject()
        {
            var sek = new Money(1000, Currency.SEK);
            Assert.IsType<Currency>(sek.Currency);
            Assert.Equal(Currency.SEK, sek.Currency);
            Assert.Equal(1000, sek.Fractional);

            var usd = new Money(4999, Currency.USD);
            Assert.IsType<Currency>(usd.Currency);
            Assert.Equal(Currency.USD, usd.Currency);
            Assert.Equal(4999, usd.Fractional);
        }

        [Fact]
        public void ShouldAddRateOnBank()
        {
            //Assert.Equal(2, Money.Bank.Rates.Count);

            var money = new Money(1000, Currency.SEK);
            Assert.Equal(Currency.SEK, money.Currency);
            Assert.Equal(typeof(VariableExchange), Money.Bank.GetType());

            var rate1 = Money.Bank.Get(Currency.SEK, Currency.USD);
            Assert.Equal(rate1.From, Currency.SEK);
            Assert.Equal(rate1.To, Currency.USD);
            Assert.Equal((decimal)0.109133, rate1.Value);

            var rate2 = Money.Bank.Get(Currency.USD, Currency.SEK);
            Assert.Equal(rate2.From, Currency.USD);
            Assert.Equal(rate2.To, Currency.SEK);
            Assert.Equal((decimal)9.16479, rate2.Value);
        }

        [Fact]
        public void ShouldReturnAmountInFractionalUnit()
        {
            var m1 = new Money(100, Currency.USD);
            Assert.Equal(100, m1.Fractional);

            var m2 = new Money(4900, Currency.USD);
            Assert.Equal(4900, m2.Fractional);

            var m3 = new Money(4999, Currency.USD);
            Assert.Equal(4999, m3.Fractional);
        }

        [Fact]
        public void ShouldChangeRoundingMode()
        {
            var m1 = new Money(1950, Currency.USD);
            Assert.Equal(1950, m1.Fractional);

            var m2 = new Money(2999, Currency.USD, MidpointRounding.AwayFromZero);
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
    }
}
