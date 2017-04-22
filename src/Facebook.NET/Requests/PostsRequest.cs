using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public class PostsRequest : PagedRequest
    {
        public string PageId { get; }
        public PostsRequestEdge Edge { get; }
        public IEnumerable<PostField> Fields { get; set; }

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
            RequestFields.Serialize(Fields, builder);
            base.Format(builder);
        }
    }
}
