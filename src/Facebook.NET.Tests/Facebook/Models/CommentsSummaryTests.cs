using Xunit;

namespace Facebook.Models.Tests
{
    public class CommentsSummaryTests
    {
        [Fact]
        public void ToString_Get_ReturnsExepcted()
        {
            var commentsSummary = new CommentsSummary();
            Assert.Equal(0, commentsSummary.TotalCount);
            Assert.False(commentsSummary.CanComment);
        }

        [Fact]
        public void ToString_InvokeZero_ReturnsSummary()
        {
            var commentsSummary = new CommentsSummary();
            Assert.Equal("0", commentsSummary.ToString());
        }

        [Fact]
        public void ToString_InvokeNonZero_ReturnsSummary()
        {
            var commentsSummary = new CommentsSummary { TotalCount = 10 };
            Assert.Equal("10", commentsSummary.ToString());
        }
    }
}
