﻿using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class PostsRequestTests
    {
        [Fact]
        public void Ctor_ValidPageIdAndEdge_ReturnsExpected()
        {
            var postsRequest = new PostsRequest("PageId", PostsRequestEdge.Posts);
            Assert.Equal("PageId", postsRequest.PageId);
            Assert.Equal(PostsRequestEdge.Posts, postsRequest.Edge);
            Assert.Null(postsRequest.Fields);
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