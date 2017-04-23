using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class CommentsRequestTests
    {
        [Fact]
        public void Ctor_ValidParentId_ReturnsExpected()
        {
            var commentsRequest = new CommentsRequest("ParentId");
            Assert.Equal("ParentId", commentsRequest.ParentId);
            Assert.Null(commentsRequest.Fields);
            Assert.Equal("fields=id,message,from,like_count,comment_count,parent,created_time,updated_time&", commentsRequest.ToString());
        }

        [Fact]
        public void Ctor_NullParentId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("parentId", () => new CommentsRequest(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyParentId_ThrowsArgumentException(string parentId)
        {
            Assert.Throws<ArgumentException>("parentId", () => new CommentsRequest(parentId));
        }
    }
}
