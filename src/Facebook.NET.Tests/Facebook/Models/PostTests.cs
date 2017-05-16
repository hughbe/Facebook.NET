using Facebook.Models;
using Xunit;

namespace Facebook.Models.Tests
{
    public class PostTests
    {
        [Fact]
        public void Reactions_Get_ReturnsNonNull()
        {
            var post = new Post();
            Assert.Equal(0, post.Reactions.Summary.TotalCount);
            Assert.Equal(ReactionType.None, post.Reactions.Summary.ViewerReaction);
        }

        [Fact]
        public void Comments_Get_ReturnsNonNull()
        {
            var post = new Post();
            Assert.Equal(0, post.Comments.Summary.TotalCount);
            Assert.False(post.Comments.Summary.CanComment);
        }

        [Fact]
        public void Shares_Get_ReturnsNonNull()
        {
            var post = new Post();
            Assert.Equal(0, post.Shares.Count);
        }
    }
}