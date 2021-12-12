using Xunit;

namespace Money.Tests
{
    public class MoneyArithmeticTests
    {
        [Fact]
        public void ShouldCreateMoneyObject()
        {
            Assert.Equal(150000, (new Money(1000, Currency.USD) + new Money(500, Currency.USD)).Cents);
            Assert.Equal(80000, (new Money(1000, Currency.USD) - new Money(200, Currency.USD)).Cents);
            Assert.Equal(50000, (new Money(1000, Currency.USD) / 2).Cents);
            Assert.Equal(500000, (new Money(1000, Currency.USD) * 5).Cents);
        }
    }
}
