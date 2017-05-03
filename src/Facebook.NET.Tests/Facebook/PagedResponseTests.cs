using System;
using Xunit;

namespace Facebook.Tests
{
    public class PagedResponseTests
    {
        [Fact]
        public void Ctor_Empty_ReturnsExpected()
        {
            var response = new PagedResponse();
            Assert.Equal(0, response.PageNumber);
            Assert.Equal(0, response.PageSize);
            Assert.Equal(0, response.StartItemIndex);
            Assert.Equal(0, response.EndItemIndex);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 2, 0, 2)]
        [InlineData(2, 1, 1, 2)]
        public void Ctor_ValidPageNumberPageSize_ReturnsExpected(int pageNumber, int pageSize, int expectedStartItemIndex, int expectedEndItemIndex)
        {
            var response = new PagedResponse(pageNumber, pageSize);
            Assert.Equal(pageNumber, response.PageNumber);
            Assert.Equal(pageSize, response.PageSize);
            Assert.Equal(expectedStartItemIndex, response.StartItemIndex);
            Assert.Equal(expectedEndItemIndex, response.EndItemIndex);
        }

        [Fact]
        public void Ctor_NegativePageNumber_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>("value", () => new PagedResponse(-1, 1));
        }

        [Fact]
        public void Ctor_NegativePageSize_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>("value", () => new PagedResponse(1, -1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void PageNumber_SetValid_ReturnsExpected(int value)
        {
            var response = new PagedResponse() { PageNumber = value };
            Assert.Equal(value, response.PageNumber);
        }

        [Fact]
        public void PageSize_SetNegative_ThrowsArgumentOutOfRangeException()
        {
            var response = new PagedResponse();
            Assert.Throws<ArgumentOutOfRangeException>("value", () => response.PageSize = -1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void PageSize_SetValid_ReturnsExpected(int value)
        {
            var response = new PagedResponse() { PageSize = value };
            Assert.Equal(value, response.PageSize);
        }

        [Fact]
        public void PageNumber_SetNegative_ThrowsArgumentOutOfRangeException()
        {
            var response = new PagedResponse();
            Assert.Throws<ArgumentOutOfRangeException>("value", () => response.PageNumber = -1);
        }
    }
}
