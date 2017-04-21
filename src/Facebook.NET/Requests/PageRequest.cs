using Facebook.NET.Requests;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public class PageRequest : Request
    {
        public string PageId { get; set; }
        public IEnumerable<PageField> Fields { get; set; }

        internal override void Format(StringBuilder builder)
        {
            RequestFields.Serialize(Fields, builder);
        }
    }
}
