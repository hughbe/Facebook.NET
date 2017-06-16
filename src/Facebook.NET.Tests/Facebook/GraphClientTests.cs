using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Models;
using Xunit;

namespace Facebook.Tests
{
    public class GraphClientTests
    {
        public static IEnumerable<object[]> Ctor_ValidVersion_TestData()
        {
            yield return new object[] { new Version(2, 8), "https://graph.facebook.com/v2.8" };
            yield return new object[] { new Version(2, 8, 0), "https://graph.facebook.com/v2.8" };
            yield return new object[] { new Version(2, 8, 0, 0), "https://graph.facebook.com/v2.8" };
        }

        [Theory]
        [MemberData(nameof(Ctor_ValidVersion_TestData))]
        public void Ctor_ValidVersionAppIdAppSecret_ReturnsExpected(Version version, string expectedGraphApiBase)
        {
            var client = new GraphClient(version, "AppId", "AppSecret");
            Assert.Equal(version, client.Version);
            Assert.Equal("AppId|AppSecret", client.AccessToken);
            Assert.Equal(expectedGraphApiBase, client.GraphApiBase);
        }

        [Fact]
        public void Ctor_NullVersion_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("version", () => new GraphClient(null, "AppId", "AppSecret"));
        }

        public static IEnumerable<object[]> Ctor_InvalidVersion_TestData()
        {
            yield return new object[] { new Version(2, 8, 1) };
            yield return new object[] { new Version(2, 8, 0, 2) };
        }

        [Theory]
        [MemberData(nameof(Ctor_InvalidVersion_TestData))]
        public void Ctor_InvalidVersion_ThrowsArgumentException(Version version)
        {
            Assert.Throws<ArgumentException>("version", () => new GraphClient(version, "AppId", "AppSecret"));
        }

        [Fact]
        public void Ctor_NullAppId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("appId", () => new GraphClient(new Version(2, 8), null, "AppSecret"));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_InvalidAppId_ThrowsArgumentException(string appId)
        {
            Assert.Throws<ArgumentException>("appId", () => new GraphClient(new Version(2, 8), appId, "AppSecret"));
        }

        [Fact]
        public void Ctor_NullAppSecret_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("appSecret", () => new GraphClient(new Version(2, 8), "AppId", null));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_InvalidAppSecret_ThrowsArgumentException(string appSecret)
        {
            Assert.Throws<ArgumentException>("appSecret", () => new GraphClient(new Version(2, 8), "AppId", appSecret));
        }

        [Fact]
        public async Task GetPost_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient(new Version(2, 8), "AppId", "AppSecret");
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPost<Post>(null));
        }

        [Fact]
        public async Task GetPosts_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient(new Version(2, 8), "AppId", "AppSecret");
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPosts<Post>(null));
        }

        [Fact]
        public async Task GetComment_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient(new Version(2, 8), "AppId", "AppSecret");
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetComment<Comment>(null));
        }

        [Fact]
        public async Task GetComments_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient(new Version(2, 8), "AppId", "AppSecret");
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetComments<Comment>(null));
        }

        [Fact]
        public async Task GetPage_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient(new Version(2, 8), "AppId", "AppSecret");
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPage<Page>(null));
        }
    }
}
