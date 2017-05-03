using System;
using System.Text;

namespace Facebook.Requests
{
    public class CommentsRequest : PagedRequest
    {
        /// <summary>
        /// Gets the Id of the parent (a post or a comment) of the comments to fetch from the Facebook Graph API.
        /// </summary>
        public string ParentId { get; }

        /// <summary>
        /// Constructs a request for the endpoint https://graph.facebook.com/vX.Y/{ParentId}/comment.
        /// </summary>
        /// <param name="parentId">The Id of the parent (a post or a comment) of the comments to fetch from the Facebook Graph API.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parentId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="parentId"/> is empty or whitespace.</exception>
        public CommentsRequest(string parentId)
        {
            if (parentId == null)
            {
                throw new ArgumentNullException(nameof(parentId));
            }
            if (string.IsNullOrWhiteSpace(parentId))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(parentId));
            }

            ParentId = parentId;
        }

        internal override void Format(StringBuilder builder)
        {
            builder.Append($"/{ParentId}/comments?");
            RequestFields.Serialize(Fields ?? RequestFields.DefaultCommentFields, builder);
            base.Format(builder);
        }
    }
}
