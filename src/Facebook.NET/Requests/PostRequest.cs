using System;
using System.Text;

namespace Facebook.Requests
{
    public class PostRequest : Request
    {
        /// <summary>
        /// Gets the Id of the comment to fetch from the Facebook Graph API.
        /// </summary>
        public string PostId { get; }

        /// <summary>
        /// Constructs a request for the endpoint https://graph.facebook.com/vX.Y/{PostId}.
        /// </summary>
        /// <param name="postId">The Id of the post to fetch from the Facebook Graph API.</param>
        /// <exception cref="ArgumentNullException"><paramref name="postId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="postId"/> is empty or whitespace.</exception>
        public PostRequest(string postId)
        {
            if (postId == null)
            {
                throw new ArgumentNullException(nameof(postId));
            }
            if (string.IsNullOrWhiteSpace(postId))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(postId));
            }

            PostId = postId;
        }

        internal override void Format(StringBuilder builder)
        {
            builder.Append($"/{PostId}?");
            RequestFields.Serialize(Fields ?? RequestFields.DefaultPostFields, builder);
        }
    }
}
