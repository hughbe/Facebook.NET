using System;
using System.Text;

namespace Facebook.Requests
{
    public class PostRequest : Request
    {
        public string PostId { get; }

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
