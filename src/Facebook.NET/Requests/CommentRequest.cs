using System;
using System.Text;

namespace Facebook.Requests
{
    public class CommentRequest : Request
    {
        /// <summary>
        /// Gets the Id of the comment to fetch from the Facebook Graph API.
        /// </summary>
        public string CommentId { get;  }

        /// <summary>
        /// Constructs a request for the endpoint https://graph.facebook.com/vX.Y/{CommentId}.
        /// </summary>
        /// <param name="commentId">The Id of the comment to fetch from the Facebook Graph API.</param>
        /// <exception cref="ArgumentNullException"><paramref name="commentId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="commentId"/> is empty or whitespace.</exception>
        public CommentRequest(string commentId)
        {
            if (commentId == null)
            {
                throw new ArgumentNullException(nameof(commentId));
            }
            if (string.IsNullOrWhiteSpace(commentId))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(commentId));
            }

            CommentId = commentId;
        }

        internal override void Format(StringBuilder builder)
        {
            builder.Append($"/{CommentId}?");
            RequestFields.Serialize(Fields ?? RequestFields.DefaultCommentFields, builder);
        }
    }
}
