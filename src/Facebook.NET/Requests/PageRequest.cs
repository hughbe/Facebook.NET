using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public class PageRequest : Request
    {
        public string PageId { get; }
        public IEnumerable<PageField> Fields { get; set; }

        public PageRequest(string pageId)
        {
            if (pageId == null)
            {
                throw new ArgumentNullException(nameof(pageId));
            }
            if (string.IsNullOrWhiteSpace(pageId))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(pageId));
            }

            PageId = pageId;
        }

        internal override void Format(StringBuilder builder)
        {
            RequestFields.Serialize(Fields, builder);
        }
    }
}
