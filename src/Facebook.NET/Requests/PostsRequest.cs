﻿using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public class PostsRequest : PagedRequest
    {
        public string PageId { get; set; }
        public PostsRequestEdge Edge { get; set; }
        public IEnumerable<PostField> Fields { get; set; }

        internal override void Format(StringBuilder builder)
        {
            RequestFields.Serialize(Fields, builder);
            base.Format(builder);
        }
    }
}
