using Xunit;

namespace Money.Tests
{
    public class CurrencyComparisonTests
    {
        [Fact]
        public void ShouldBeComparable()
        {
            Assert.True(Currency.SEK == Currency.SEK);
            Assert.False(Currency.SEK == Currency.USD);

            Assert.True(Currency.SEK != Currency.USD);
            Assert.False(Currency.SEK != Currency.SEK);

            Assert.True(Currency.SEK.Equals(Currency.SEK));
            Assert.False(Currency.SEK.Equals(Currency.USD));
        }
    }
}
