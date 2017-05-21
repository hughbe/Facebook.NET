using System;
using System.Text;

namespace Facebook.Requests
{
    public class PostsRequest : PagedRequest
    {
        /// <summary>
        /// Gets the Id of the page to fetch posts from the Facebook Graph API.
        /// </summary>
        public string PageId { get; }

        /// <summary>
        /// Gets the type of posts to fetch from the Facebook Graph API.
        /// </summary>
        public PostsRequestEdge Edge { get; }

        /// <summary>
        /// Constructs a request for the endpoint https://graph.facebook.com/vX.Y/{PageId}/{Edge}.
        /// </summary>
        /// <param name="pageId">The Id of the page to fetch posts from the Facebook Graph API.</param>
        /// <param name="edge">The type of posts to fetch from the Facebook Graph API.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pageId"/> is null.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="pageId"/> is empty or whitespace.
        /// -or-
        /// <paramref name="edge"/> is not a valid <see cref="PostsRequestEdge"/> value
        /// </exception>
        public PostsRequest(string pageId, PostsRequestEdge edge)
        {
            if (pageId == null)
            {
                throw new ArgumentNullException(nameof(pageId));
            }
            if (string.IsNullOrWhiteSpace(pageId))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(pageId));
            }
            if (!Enum.IsDefined(typeof(PostsRequestEdge), edge))
            {
                throw new ArgumentException("Argument is not a valid enum.", nameof(edge));
            }

            PageId = pageId;
            Edge = edge;
        }

        internal override void Format(StringBuilder builder)
        {
            builder.Append($"/{PageId}/{Edge.ToString().ToLower()}?");
            RequestFields.Serialize(Fields ?? RequestFields.DefaultPostFields, builder);
            base.Format(builder);
        }
    }
}
