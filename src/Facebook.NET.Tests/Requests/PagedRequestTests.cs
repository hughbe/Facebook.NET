using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class PagedRequestTests
    {
        [Fact]
        public void Since_SetWithoutUntil_ReturnsExpected()
        {
            var since = new DateTime(2017, 04, 20);
            var pagedRequest = new PagedRequest() { Since = since };
            Assert.Equal(since, pagedRequest.Since);
            Assert.Equal("since=1492646400&", pagedRequest.ToString());
        }

        [Fact]
        public void Since_SetWithUntil_ReturnsExpected()
        {
            var since = new DateTime(2017, 04, 20);
            var until = new DateTime(2017, 04, 21);
            var pagedRequest = new PagedRequest() { Until = until, Since = since };
            Assert.Equal(since, pagedRequest.Since);
            Assert.Equal("since=1492646400&until=1492732800&", pagedRequest.ToString());
        }

        [Fact]
        public void Since_SetGreaterThanOrEqualToUntil_ThrowsArgumentOutOfRangeException()
        {
            var until = new DateTime(2017, 04, 21);
            var pagedRequest = new PagedRequest() { Until = until };
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.Since = until);
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.Since = until.AddTicks(1));
        }

        [Fact]
        public void Since_SetGreaterThanNow_ThrowsArgumentOutOfRangeException()
        {
            var pagedRequest = new PagedRequest();
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.Since = DateTime.Now.AddDays(1));
        }

        [Fact]
        public void Until_SetWithoutSince_ReturnsExpected()
        {
            var until = new DateTime(2017, 04, 21);
            var pagedRequest = new PagedRequest() { Until = until };
            Assert.Equal(until, pagedRequest.Until);
            Assert.Equal("until=1492732800&", pagedRequest.ToString());
        }

        [Fact]
        public void Until_SetWithSince_ReturnsExpected()
        {
            var since = new DateTime(2017, 04, 20);
            var until = new DateTime(2017, 04, 21);
            var pagedRequest = new PagedRequest() { Since = since, Until = until };
            Assert.Equal(until, pagedRequest.Until);
            Assert.Equal("since=1492646400&until=1492732800&", pagedRequest.ToString());
        }

        [Fact]
        public void Until_SetLessThanOrEqualToSince_ThrowsArgumentOutOfRangeException()
        {
            var since = new DateTime(2017, 04, 20);
            var pagedRequest = new PagedRequest() { Since = since };
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.Until = since);
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.Until = since.AddTicks(-1));
        }

        [Fact]
        public void Until_SetGreaterThanNow_ThrowsArgumentOutOfRangeException()
        {
            var pagedRequest = new PagedRequest();
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.Until = DateTime.Now.AddDays(1));
        }

        [Theory]
        [InlineData(1, "limit=1&")]
        [InlineData(100, "limit=100&")]
        [InlineData(200, "limit=200&")]
        public void PaginationLimit_SetValid_ReturnsExpected(int paginationLimit, string expectedToString)
        {
            var pagedRequest = new PagedRequest() { PaginationLimit = paginationLimit };
            Assert.Equal(paginationLimit, pagedRequest.PaginationLimit);
            Assert.Equal(expectedToString, pagedRequest.ToString());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void PaginationLimit_SetInvalid_ThrowsArgumentOutOfRangeException(int paginationLimit)
        {
            var pagedRequest = new PagedRequest();
            Assert.Throws<ArgumentOutOfRangeException>("value", () => pagedRequest.PaginationLimit = paginationLimit);
        }

        [Fact]
        public void ToString_PaginationLimitSinceUntil_ReturnsExpected()
        {
            var since = new DateTime(2017, 04, 20);
            var until = new DateTime(2017, 04, 21);
            var pagedRequest = new PagedRequest()
            {

                PaginationLimit = 100,
                Since = since,
                Until = until
            };
            Assert.Equal("limit=100&since=1492646400&until=1492732800&", pagedRequest.ToString());
        }
    }
}
