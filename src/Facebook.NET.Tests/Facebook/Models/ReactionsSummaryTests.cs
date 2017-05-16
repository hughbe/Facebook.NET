using Xunit;

namespace Facebook.Models.Tests
{
    public class ReactionsSummaryTests
    {
        [Fact]
        public void ToString_Get_ReturnsExepcted()
        {
            var reactionsSummary = new ReactionsSummary();
            Assert.Equal(0, reactionsSummary.TotalCount);
            Assert.Equal(ReactionType.None, reactionsSummary.ViewerReaction);
        }

        [Fact]
        public void ToString_InvokeZero_ReturnsSummary()
        {
            var reactionsSummary = new ReactionsSummary();
            Assert.Equal("0", reactionsSummary.ToString());
        }

        [Fact]
        public void ToString_InvokeNonZero_ReturnsSummary()
        {
            var reactionsSummary = new ReactionsSummary { TotalCount = 10 };
            Assert.Equal("10", reactionsSummary.ToString());
        }
    }
}
