using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facebook.Requests
{
    internal static class RequestFields
    {
        private static IEnumerable<RequestField> _defaultPageFields;
        internal static IEnumerable<RequestField> DefaultPageFields
        {
            get
            {
                if (_defaultPageFields == null)
                {
                    _defaultPageFields = new RequestField[]
                    {
                        RequestField.Id, RequestField.Name, RequestField.FanCount, RequestField.Category
                    };
                }
                return _defaultPageFields;
            }
        }

        private static IEnumerable<RequestField> _defaultPostFields;
        internal static IEnumerable<RequestField> DefaultPostFields
        {
            get
            {
                if (_defaultPostFields == null)
                {
                    _defaultPostFields = new RequestField[]
                    {
                        RequestField.Id,          RequestField.Message,    RequestField.Link,    RequestField.Caption,
                        RequestField.Description, RequestField.Poster,     RequestField.Created, RequestField.Updated,
                        RequestField.Permalink,   RequestField.StatusType, RequestField.Type,    RequestField.Name,
                        RequestField.Place,       RequestField.Shares,
                        RequestField.Comments.Limit(0).Summary(true),      RequestField.Reactions.Limit(0).Summary(true),
                    };
                }
                return _defaultPostFields;
            }
        }

        private static IEnumerable<RequestField> _defaultCommentFields;
        internal static IEnumerable<RequestField> DefaultCommentFields
        {
            get
            {
                if (_defaultCommentFields == null)
                {
                    _defaultCommentFields = new RequestField[]
                    {
                        RequestField.Id,              RequestField.Message,       RequestField.Poster,  RequestField.NumberOfLikes,
                        RequestField.NumberOfReplies, RequestField.ParentComment, RequestField.Created, RequestField.Updated
                    };
                }

                return _defaultCommentFields;
            }
        }

        public static void Serialize(IEnumerable<RequestField> commentFields, StringBuilder builder)
        {
            RequestField[] fields = commentFields.ToArray();

            builder.Append("fields=");
            for (int i = 0; i < fields.Length; i++)
            {
                RequestField field = fields[i];
                field.Format(builder);

                if (i != fields.Length - 1)
                {
                    builder.Append(',');
                }
            }

            builder.Append("&");
        }
    }
}
