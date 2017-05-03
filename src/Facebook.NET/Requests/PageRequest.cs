using System;
using System.Text;

namespace Facebook.Requests
{
    public class PageRequest : Request
    {
        /// <summary>
        /// Gets the Id of the comment to fetch from the Facebook Graph API.
        /// </summary>
        public string PageId { get; }

        /// <summary>
        /// Constructs a request for the endpoint https://graph.facebook.com/vX.Y/{PageId}.
        /// </summary>
        /// <param name="pageId">The Id of the page to fetch from the Facebook Graph API.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pageId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="pageId"/> is empty or whitespace.</exception>
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
            builder.Append($"/{PageId}?");
            RequestFields.Serialize(Fields ?? RequestFields.DefaultPageFields, builder);
        }
    }
}
