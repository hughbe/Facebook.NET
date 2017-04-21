using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    class PostRequest : Request
    {
        public string PostId { get; set; }
        public IEnumerable<PostField> Fields { get; set; }

        internal override void Format(StringBuilder builder)
        {
            RequestFields.Serialize(Fields, builder);
        }
    }
}
