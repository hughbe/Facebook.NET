using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Models;
using Xunit;

namespace Facebook.Tests
{
    public class GraphClientTests
    {
        [Fact]
        public void Ctor_String_String()
        {
            var client = new GraphClient("AppId", "AppSecret");
            Assert.Equal("AppId|AppSecret", client.AccessToken);
            Assert.Null(client.Version);
            Assert.Equal("https://graph.facebook.com", client.GraphApiBase);
        }

        public static IEnumerable<object[]> Ctor_ValidVersion_TestData()
        {
            yield return new object[] { null, "https://graph.facebook.com" };
            yield return new object[] { new Version(2, 8), "https://graph.facebook.com/v2.8" };
            yield return new object[] { new Version(2, 8, 0), "https://graph.facebook.com/v2.8" };
            yield return new object[] { new Version(2, 8, 0, 0), "https://graph.facebook.com/v2.8" };
        }

        [Theory]
        [MemberData(nameof(Ctor_ValidVersion_TestData))]
        public void Ctor_String_String_Version(Version version, string expectedGraphApiBase)
        {
            var client = new GraphClient("AppId", "AppSecret", version);
            Assert.Equal("AppId|AppSecret", client.AccessToken);
            Assert.Equal(version, client.Version);
            Assert.Equal(expectedGraphApiBase, client.GraphApiBase);
        }

        [Fact]
        public void Ctor_NullAppId_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("appId", () => new GraphClient(null, "AppSecret"));
            Assert.Throws<ArgumentNullException>("appId", () => new GraphClient(null, "AppSecret", new Version(2, 8)));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_InvalidAppId_ThrowsArgumentException(string appId)
        {
            Assert.Throws<ArgumentException>("appId", () => new GraphClient(appId, "AppSecret"));
            Assert.Throws<ArgumentException>("appId", () => new GraphClient(appId, "AppSecret", new Version(2, 8)));
        }

        [Fact]
        public void Ctor_NullAppSecret_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("appSecret", () => new GraphClient("AppId", null));
            Assert.Throws<ArgumentNullException>("appSecret", () => new GraphClient("AppId", null, new Version(2, 8)));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public void Ctor_InvalidAppSecret_ThrowsArgumentException(string appSecret)
        {
            Assert.Throws<ArgumentException>("appSecret", () => new GraphClient("AppId", appSecret));
            Assert.Throws<ArgumentException>("appSecret", () => new GraphClient("AppId", appSecret, new Version(2, 8)));
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
            Assert.Throws<ArgumentException>("version", () => new GraphClient("AppId", "AppSecret", version));
        }

        [Fact]
        public async Task GetPost_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient("AppId", "AppSecret", new Version(2, 8));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPost(null));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPost<Post>(null));
        }

        [Fact]
        public async Task GetPosts_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient("AppId", "AppSecret", new Version(2, 8));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPosts(null));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPosts<Post>(null));
        }

        [Fact]
        public async Task GetComment_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient("AppId", "AppSecret", new Version(2, 8));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetComment(null));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetComment<Comment>(null));
        }

        [Fact]
        public async Task GetComments_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient("AppId", "AppSecret", new Version(2, 8));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetComments(null));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetComments<Comment>(null));
        }

        [Fact]
        public async Task GetPage_NullRequest_ThrowsArgumentNullException()
        {
            var client = new GraphClient("AppId", "AppSecret", new Version(2, 8));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPage(null));
            await Assert.ThrowsAsync<ArgumentNullException>("request", () => client.GetPage<Page>(null));
        }
    }
}
