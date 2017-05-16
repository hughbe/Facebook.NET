using Xunit;

namespace Facebook.Models.Tests
{
    public class ReactionsTests
    {
        [Fact]
        public void Ctor_Default_ReturnsExpected()
        {
            var reactions = new Reactions();
            Assert.Equal(0, reactions.Summary.TotalCount);
            Assert.Equal(ReactionType.None, reactions.Summary.ViewerReaction);
        }

        [Fact]
        public void ToString_InvokeZero_ReturnsSummary()
        {
            var reactions = new Reactions();
            Assert.Equal("0", reactions.ToString());
        }

        [Fact]
        public void ToString_InvokeNonZero_ReturnsSummary()
        {
            var reactions = new Reactions();
            reactions.Summary.TotalCount = 10;
            Assert.Equal("10", reactions.ToString());
        }
    }
}
