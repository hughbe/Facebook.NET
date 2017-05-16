using Xunit;

namespace Facebook.Models.Tests
{
    public class CommentsTests
    {
        [Fact]
        public void Ctor_Default_ReturnsExpected()
        {
            var comments = new Comments();
            Assert.Equal(0, comments.Summary.TotalCount);
            Assert.False(comments.Summary.CanComment);
        }

        [Fact]
        public void ToString_InvokeZero_ReturnsSummary()
        {
            var comments = new Comments();
            Assert.Equal("0", comments.ToString());
        }

        [Fact]
        public void ToString_InvokeNonZero_ReturnsSummary()
        {
            var comments = new Comments();
            comments.Summary.TotalCount = 10;
            Assert.Equal("10", comments.ToString());
        }
    }
}
