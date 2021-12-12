using Xunit;

namespace Money.Tests
{
    public class MoneyComparisonTests
    {
        [Fact]
        public void ShouldBeComparable()
        {
            Assert.True(new Money(1000, Currency.SEK) == new Money(1000, Currency.SEK));
            Assert.False(new Money(1000, Currency.SEK) == new Money(1000, Currency.USD));

            Assert.True(new Money(1000, Currency.SEK) != new Money(1000, Currency.USD));
            Assert.False(new Money(1000, Currency.SEK) != new Money(1000, Currency.SEK));

            Assert.True(new Money(1000, Currency.SEK).Equals(new Money(1000, Currency.SEK)));
            Assert.False(new Money(1000, Currency.SEK).Equals(new Money(1000, Currency.USD)));

            Assert.False(new Money(1000, Currency.SEK) == new Money(100, Currency.SEK));
            Assert.True(new Money(1000, Currency.SEK) != new Money(100, Currency.SEK));

            Assert.True(Money.FromAmount(5, Currency.USD) == Money.FromAmount(5, Currency.USD));
            Assert.True(Money.FromAmount(5, Currency.USD) != Money.FromAmount(5, Currency.SEK));
            Assert.False(Money.FromAmount(5, Currency.USD) == Money.FromAmount(5, Currency.SEK));

            //Assert.True(Money.FromAmount(5, Currency.JPY) == Money.FromAmount(5, Currency.JPY));
            //Assert.True(Money.FromAmount(5, Currency.JPY) != Money.FromAmount(5, Currency.SEK));
            //Assert.False(Money.FromAmount(5, Currency.JPY) == Money.FromAmount(5, Currency.SEK));

            //Assert.True(Money.FromAmount(5, Currency.TND) == Money.FromAmount(5, Currency.TND));
            //Assert.True(Money.FromAmount(5, Currency.TND) != Money.FromAmount(5, Currency.SEK));
            //Assert.False(Money.FromAmount(5, Currency.TND) == Money.FromAmount(5, Currency.SEK));
        }

        [Fact]
        public void ShouldBeAbleToCompareCurrency()
        {
            Assert.True(new Money(1000, Currency.EUR).Currency == Currency.EUR);
            Assert.True(new Money(1000, Currency.EUR).Currency.Equals(Currency.EUR));
            Assert.True(new Money(1000, Currency.EUR).Currency != Currency.USD);
        }
    }
}
