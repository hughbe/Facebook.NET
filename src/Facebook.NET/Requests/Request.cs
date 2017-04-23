using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public abstract class Request
    {
        public IEnumerable<RequestField> Fields { get; set; }

        internal abstract void Format(StringBuilder builder);
    }
}
