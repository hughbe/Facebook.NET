using System;
using System.Text;

namespace Facebook.Requests
{
    public class RequestField
    {
        public string FieldName { get; }

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

        // Global
        public static RequestField Id => new RequestField("id");
        public static RequestField Created => new RequestField("created_time");
        public static RequestField Updated => new RequestField("updated_time");

        // Post, Comment
        public static RequestField Message => new RequestField("message");
        public static RequestField Poster => new RequestField("from");

        // Post
        public static RequestField Link => new RequestField("link");
        public static RequestField Caption => new RequestField("caption");
        public static RequestField Description => new RequestField("description");
        public static RequestField Permalink => new RequestField("permalink_url");
        public static RequestField StatusType => new RequestField("status_type");
        public static RequestField CallToAction => new RequestField("call_to_action");
        public static RequestField Type => new RequestField("type");
        public static RequestField Name => new RequestField("name");
        public static RequestField Place => new RequestField("place");
        public static ListRequestField Comments => new ListRequestField("comments");
        public static ListRequestField Reactions => new ListRequestField("reactions");
        public static RequestField Shares => new ListRequestField("shares");

        // Comment
        public static RequestField NumberOfLikes => new RequestField("like_count");
        public static RequestField NumberOfReplies => new RequestField("comment_count");
        public static RequestField ParentComment => new RequestField("parent");

        // Page
        public static RequestField FanCount => new RequestField("fan_count");
        public static RequestField Category => new RequestField("category");

        internal virtual void Serialize(StringBuilder builder) => builder.Append(FieldName);

        public override string ToString()
        {
            var builder = new StringBuilder();
            Serialize(builder);
            return builder.ToString();
        }
    }
}

