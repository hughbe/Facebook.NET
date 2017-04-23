using System;
using System.Text;

namespace Facebook.Requests
{
    public class CommentsRequest : PagedRequest
    {
        public string ParentId { get; }

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
