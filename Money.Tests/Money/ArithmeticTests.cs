using Xunit;

namespace Money.Tests
{
    public class MoneyArithmeticTests
    {
        [Fact]
        public void ShouldCreateMoneyObject()
        {
            Assert.Equal(1500, (new Money(1000, Currency.USD) + new Money(500, Currency.USD)).Cents);
            Assert.Equal(1500, (new Money(1000, Currency.USD) + 500).Cents);
            Assert.Equal(800, (new Money(1000, Currency.USD) - new Money(200, Currency.USD)).Cents);
            Assert.Equal(800, (new Money(1000, Currency.USD) - 200).Cents);
            Assert.Equal(500, (new Money(1000, Currency.USD) / 2).Cents);
            Assert.Equal(5000, (new Money(1000, Currency.USD) * 5).Cents);

            Assert.Equal("$10.90", (new Money(10_00, Currency.USD) + new Money(90, Currency.USD)).ToString());
            Assert.Equal("$10.90", (new Money(10_00, Currency.USD) + 90).ToString());
            Assert.Equal("$10.00", (new Money(10_00, Currency.USD) + new Money(0, Currency.USD)).ToString());
            Assert.Equal("$10.00", (new Money(10_00, Currency.USD) + 0).ToString());
        }
    }
}
