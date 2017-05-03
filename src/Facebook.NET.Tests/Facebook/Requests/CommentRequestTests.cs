using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class CommentRequestTests
    {
        [Fact]
        public void Ctor_ValidCommentId_ReturnsExpected()
        {
            var commentRequest = new CommentRequest("CommentId");
            Assert.Equal("CommentId", commentRequest.CommentId);
            Assert.Null(commentRequest.Fields);
            Assert.Equal("/CommentId?fields=id,message,from,like_count,comment_count,parent,created_time,updated_time&", commentRequest.ToString());
        }

        [Fact]
        public void Ctor_NullCommentId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("commentId", () => new CommentRequest(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyCommentId_ThrowsArgumentException(string commentId)
        {
            Assert.Throws<ArgumentException>("commentId", () => new CommentRequest(commentId));
        }
    }
}
