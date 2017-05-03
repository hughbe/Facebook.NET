using System;
using System.Text;

namespace Facebook.Requests
{
    public class RequestField
    {
        /// <summary>
        /// Gets the name of the field of an object to fetch from the Facebook Graph API.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// Constructs a field of an object to fetch from the Facebook Graph API.
        /// </summary>
        /// <param name="fieldName">The name of the field of an object to fetch from the Facebook Graph API.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is empty or whitespace.</exception>
        public RequestField(string fieldName)
        {
            if (fieldName == null)
            {
                throw new ArgumentNullException(nameof(fieldName));
            }
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(fieldName));
            }

            FieldName = fieldName;
        }
        
        /// <summary>
        /// The field named "id" in the Facebook Graph API. This is common to all objects.
        /// </summary>
        public static RequestField Id => new RequestField("id");

        /// <summary>
        /// The field named "created_time" in the Facebook Graph API. This is common to all objects.
        /// </summary>
        public static RequestField Created => new RequestField("created_time");

        /// <summary>
        /// The field named "updated_time" in the Facebook Graph API. This is common to all objects.
        /// </summary>
        public static RequestField Updated => new RequestField("updated_time");

        /// <summary>
        /// The field named "message" in the Facebook Graph API. This is common to posts and comments.
        /// </summary>
        public static RequestField Message => new RequestField("message");

        /// <summary>
        /// The field named "from" in the Facebook Graph API. This is common to posts and comments.
        /// </summary>
        public static RequestField Poster => new RequestField("from");

        /// <summary>
        /// The field named "link" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Link => new RequestField("link");

        /// <summary>
        /// The field named "caption" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Caption => new RequestField("caption");

        /// <summary>
        /// The field named "description" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Description => new RequestField("description");

        /// <summary>
        /// The field named "permalink_url" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Permalink => new RequestField("permalink_url");

        /// <summary>
        /// The field named "status_type" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField StatusType => new RequestField("status_type");

        /// <summary>
        /// The field named "call_to_action" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField CallToAction => new RequestField("call_to_action");

        /// <summary>
        /// The field named "call_to_action" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Type => new RequestField("type");

        /// <summary>
        /// The field named "name" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Name => new RequestField("name");

        /// <summary>
        /// The field named "place" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Place => new RequestField("place");

        /// <summary>
        /// The field named "comments" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static ListRequestField Comments => new ListRequestField("comments");

        /// <summary>
        /// The field named "reactions" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static ListRequestField Reactions => new ListRequestField("reactions");

        /// <summary>
        /// The field named "shares" in the Facebook Graph API. This is common to posts only.
        /// </summary>
        public static RequestField Shares => new ListRequestField("shares");

        /// <summary>
        /// The field named "like_count" in the Facebook Graph API. This is common to coments only.
        /// </summary>
        public static RequestField NumberOfLikes => new RequestField("like_count");

        /// <summary>
        /// The field named "comment_count" in the Facebook Graph API. This is common to coments only.
        /// </summary>
        public static RequestField NumberOfReplies => new RequestField("comment_count");

        /// <summary>
        /// The field named "parent" in the Facebook Graph API. This is common to coments only.
        /// </summary>
        public static RequestField ParentComment => new RequestField("parent");

        /// <summary>
        /// The field named "fan_count" in the Facebook Graph API. This is common to pages only.
        /// </summary>
        public static RequestField FanCount => new RequestField("fan_count");

        /// <summary>
        /// The field named "category" in the Facebook Graph API. This is common to pages only.
        /// </summary>
        public static RequestField Category => new RequestField("category");

        internal virtual void Format(StringBuilder builder) => builder.Append(FieldName);

        /// <summary>
        /// Gets the formatted value of the field that will be included in the request to the Facebook Graph API.
        /// </summary>
        /// <returns>The formatted value of the field that will be included in the request to the Facebook Graph API.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            Format(builder);
            return builder.ToString();
        }
    }
}

