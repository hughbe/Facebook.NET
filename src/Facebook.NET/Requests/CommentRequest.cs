using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public class CommentRequest : Request
    {
        public string CommentId { get; set; }
        public IEnumerable<CommentField> Fields { get; set; }

        internal override void Format(StringBuilder builder)
        {
            RequestFields.Serialize(Fields, builder);
        }
    }
}
