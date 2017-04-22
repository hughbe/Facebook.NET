using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class PostRequestTests
    {
        [Fact]
        public void Ctor_ValidPostId_ReturnsExpected()
        {
            var postRequest = new PostRequest("PostId");
            Assert.Equal("PostId", postRequest.PostId);
            Assert.Null(postRequest.Fields);
        }

        [Fact]
        public void Ctor_NullPostId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("postId", () => new PostRequest(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyPostId_ThrowsArgumentException(string postId)
        {
            Assert.Throws<ArgumentException>("postId", () => new PostRequest(postId));
        }
    }
}
