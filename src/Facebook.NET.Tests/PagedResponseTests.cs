using System;
using Xunit;

namespace Facebook.Tests
{
    public class PagedResponseTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void Ctor_ValidPageNumberPageSize_ReturnsExpected(int pageNumber, int pageSize)
        {
            var response = new PagedResponse(pageNumber, pageSize);
            Assert.Equal(pageNumber, response.PageNumber);
            Assert.Equal(pageSize, response.PageSize);
        }

        [Theory]
        [InlineData(-1)]
        public void Ctor_NegativePageNumber_ThrowsArgumentOutOfRangeException(int pageNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>("pageNumber", () => new PagedResponse(pageNumber, 1));
        }

        [Theory]
        [InlineData(-1)]
        public void Ctor_NegativePageSize_ThrowsArgumentOutOfRangeException(int pageSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>("pageSize", () => new PagedResponse(1, pageSize));
        }
    }
}
