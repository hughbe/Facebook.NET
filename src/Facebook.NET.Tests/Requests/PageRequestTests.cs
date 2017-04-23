using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class PageRequestTests
    {
        [Fact]
        public void Ctor_ValidPageId_ReturnsExpected()
        {
            var pageRequest = new PageRequest("PageId");
            Assert.Equal("PageId", pageRequest.PageId);
            Assert.Null(pageRequest.Fields);
            Assert.Equal("fields=id,name,fan_count,category&", pageRequest.ToString());
        }

        [Fact]
        public void Ctor_NullPageId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("pageId", () => new PageRequest(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyPageId_ThrowsArgumentException(string pageId)
        {
            Assert.Throws<ArgumentException>("pageId", () => new PageRequest(pageId));
        }
    }
}
