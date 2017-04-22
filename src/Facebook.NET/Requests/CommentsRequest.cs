using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public class CommentsRequest : PagedRequest
    {
        public string ParentId { get; }
        public IEnumerable<CommentField> Fields { get; set; }

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
            RequestFields.Serialize(Fields, builder);
            base.Format(builder);
        }
    }
}
