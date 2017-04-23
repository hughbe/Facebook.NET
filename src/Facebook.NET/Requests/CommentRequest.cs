using System;
using System.Text;

namespace Facebook.Requests
{
    public class CommentRequest : Request
    {
        public string CommentId { get;  }

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
