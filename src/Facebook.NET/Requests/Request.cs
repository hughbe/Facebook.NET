using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    public abstract class Request
    {
        /// <summary>
        /// Gets or sets the list of fields that are fetched from the Facebook Graph API.
        /// </summary>
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
