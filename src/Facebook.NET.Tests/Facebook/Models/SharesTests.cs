using Xunit;

namespace Facebook.Models.Tests
{
    public class SharesTests
    {
        [Fact]
        public void Ctor_Default_ReturnsExpected()
        {
            var shares = new Shares();
            Assert.Equal(0, shares.Count);
        }

        [Fact]
        public void ToString_InvokeZero_ReturnsSummary()
        {
            var shares = new Shares();
            Assert.Equal("0", shares.ToString());
        }

        [Fact]
        public void ToString_InvokeNonZero_ReturnsSummary()
        {
            var shares = new Shares() { Count = 10 };
            Assert.Equal("10", shares.ToString());
        }
    }
}
