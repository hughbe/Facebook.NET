using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class CommentRequetsTests
    {
        [Fact]
        public void Ctor_ValidCommentId_ReturnsExpected()
        {
            var commentRequest = new CommentRequest("CommentId");
            Assert.Equal("CommentId", commentRequest.CommentId);
            Assert.Null(commentRequest.Fields);
        }

        [Fact]
        public void Ctor_NullCommentId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("commentId", () => new CommentRequest(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyCommentId_ThrowsArgumentException(string pageId)
        {
            Assert.Throws<ArgumentException>("commentId", () => new CommentRequest(pageId));
        }
    }
}
