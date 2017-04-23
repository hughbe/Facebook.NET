using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public abstract class Request
    {
        public IEnumerable<RequestField> Fields { get; set; }

        internal abstract void Format(StringBuilder builder);

        public override string ToString()
        {
            var builder = new StringBuilder();
            Format(builder);
            return builder.ToString();
        }
    }
}
