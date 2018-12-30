using System;
using Xunit;

namespace Facebook.Requests.Tests
{
    public class ListRequestFieldTests
    {
        [Fact]
        public void Ctor_ValidFieldName_ReturnsExpected()
        {
            var listRequestField = new ListRequestField("FieldName");
            Assert.Equal("FieldName", listRequestField.FieldName);
            Assert.Null(listRequestField.RequestLimit);
            Assert.Null(listRequestField.ShowSummary);
            Assert.Equal("FieldName", listRequestField.ToString());
        }

        [Fact]
        public void Ctor_NullFieldName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("fieldName", () => new ListRequestField(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_EmptyFieldName_ThrowsArgumentException(string fieldName)
        {
            Assert.Throws<ArgumentException>("fieldName", () => new ListRequestField(fieldName));
        }

        [Fact]
        public void Limit_AlreadyHasLimit_ThrowsInvalidOperationException()
        {
            var listRequestField = new ListRequestField("FieldName").Limit(10);
            Assert.Throws<InvalidOperationException>(() => listRequestField.Limit(10));
        }

        [Theory]
        [InlineData(0, "FieldName.limit(0)")]
        [InlineData(1, "FieldName.limit(1)")]
        [InlineData(100, "FieldName.limit(100)")]
        public void Limit_Invoke_ReturnsExpected(int limit, string expectedToString)
        {
            var listRequestField = new ListRequestField("FieldName").Limit(limit);
            Assert.Equal("FieldName", listRequestField.FieldName);
            Assert.Equal(limit, listRequestField.RequestLimit);
            Assert.Null(listRequestField.ShowSummary);
            Assert.Equal(expectedToString, listRequestField.ToString());
        }

        [Fact]
        public void Limit_Invoke_ReturnsUniqueListRequestField()
        {
            var listRequestField = new ListRequestField("FieldName");
            Assert.NotSame(listRequestField, listRequestField.Limit(10));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void Limit_InvalidLimit_ThrowsArgumentOutOfRangeException(int limit)
        {
            var listRequestField = new ListRequestField("FieldName");
            Assert.Throws<ArgumentOutOfRangeException>("limit", () => listRequestField.Limit(limit));
        }

        [Fact]
        public void Summary_InvokeParameterless_ReturnsExpected()
        {
            var listRequestField = new ListRequestField("FieldName").Summary();
            Assert.Equal("FieldName", listRequestField.FieldName);
            Assert.Null(listRequestField.RequestLimit);
            Assert.True(listRequestField.ShowSummary);
            Assert.Equal("FieldName.summary(True)", listRequestField.ToString());
        }

        [Theory]
        [InlineData(true, "FieldName.summary(True)")]
        [InlineData(false, "FieldName.summary(False)")]
        public void Summary_Invoke_ReturnsExpected(bool summary, string expectedToString)
        {
            var listRequestField = new ListRequestField("FieldName").Summary(summary);
            Assert.Equal("FieldName", listRequestField.FieldName);
            Assert.Null(listRequestField.RequestLimit);
            Assert.Equal(summary, listRequestField.ShowSummary);
            Assert.Equal(expectedToString, listRequestField.ToString());
        }

        [Fact]
        public void Summary_Invoke_ReturnsUniqueListRequestField()
        {
            var listRequestField = new ListRequestField("FieldName");
            Assert.NotSame(listRequestField, listRequestField.Summary(true));
        }

        [Fact]
        public void Summary_AlreadyHasSummary_ThrowsInvalidOperationException()
        {
            var listRequestField = new ListRequestField("FieldName").Summary(true);
            Assert.Throws<InvalidOperationException>(() => listRequestField.Summary(false));
        }

        [Fact]
        public void Limit_ThenSummary_ReturnsExpected()
        {
            var listRequestField = new ListRequestField("FieldName").Limit(10).Summary(true);
            Assert.Equal("FieldName.limit(10).summary(True)", listRequestField.ToString());
        }

        [Fact]
        public void Summary_ThenLimit_ReturnsExpected()
        {
            var listRequestField = new ListRequestField("FieldName").Summary(true).Limit(10);
            Assert.Equal("FieldName.limit(10).summary(True)", listRequestField.ToString());
        }
    }
}
