using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class PostsRequestTests
    {
        [Theory]
        [InlineData(PostsRequestEdge.Feed, "feed")]
        [InlineData(PostsRequestEdge.Posts, "posts")]
        [InlineData(PostsRequestEdge.Tagged, "tagged")]
        public void Ctor_ValidPageIdAndEdge_ReturnsExpected(PostsRequestEdge edge, string expectedEdge)
        {
            var postsRequest = new PostsRequest("PageId", edge);
            Assert.Equal("PageId", postsRequest.PageId);
            Assert.Equal(edge, postsRequest.Edge);
            Assert.Null(postsRequest.Fields);
            Assert.Equal($"/PageId/{expectedEdge}?fields=id,message,link,caption,description,from,created_time,updated_time," +
                         "permalink_url,status_type,type,name,place,shares,comments.limit(0).summary(True),"                  +
                         "reactions.limit(0).summary(True)&", postsRequest.ToString());
        }

        [Fact]
        public void Ctor_NullPageId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("pageId", () => new PostsRequest(null, PostsRequestEdge.Posts));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyPageId_ThrowsArgumentException(string pageId)
        {
            Assert.Throws<ArgumentException>("pageId", () => new PostsRequest(pageId, PostsRequestEdge.Posts));
        }

        [Theory]
        [InlineData(PostsRequestEdge.Feed - 1)]
        [InlineData(PostsRequestEdge.Tagged + 1)]
        public void Ctor_InvalidEdge_ThrowsArgumentException(PostsRequestEdge edge)
        {
            Assert.Throws<ArgumentException>("edge", () => new PostsRequest("PageId", edge));
        }
    }
}
