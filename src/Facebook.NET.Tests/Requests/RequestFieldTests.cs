using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class RequestFieldTests
    {
        [Fact]
        public void Ctor_ValidFieldName_ReturnsExpected()
        {
            var requestField = new RequestField("FieldName");
            Assert.Equal("FieldName", requestField.FieldName);
            Assert.Equal("FieldName", requestField.ToString());
        }

        [Fact]
        public void Ctor_NullFieldName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("fieldName", () => new RequestField(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyFieldName_ThrowsArgumentException(string fieldName)
        {
            Assert.Throws<ArgumentException>("fieldName", () => new RequestField(fieldName));
        }
    }
}
