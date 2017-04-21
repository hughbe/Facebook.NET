using Facebook.NET.Requests;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Requests
{
    internal static class RequestFields
    {
        private static IEnumerable<PageField> _defaultPageFields;
        private static IEnumerable<PageField> DefaultPageFields
        {
            get
            {
                if (_defaultPageFields == null)
                {
                    _defaultPageFields = new PageField[] { PageField.Id, PageField.Name, PageField.Category, PageField.Category };
                }
                return _defaultPageFields;
            }
        }

        private static IEnumerable<PostField> _defaultPostFields;
        private static IEnumerable<PostField> DefaultPostFields
        {
            get
            {
                if (_defaultPostFields == null)
                {
                    _defaultPostFields = new PostField[]
                    {
                        PostField.Id,           PostField.Message, PostField.Link,    PostField.Caption,   PostField.Description,
                        PostField.Poster,       PostField.Created, PostField.Updated, PostField.Permalink, PostField.StatusType,
                        PostField.CallToAction, PostField.Type,    PostField.Name,    PostField.Place,     PostField.Comments,
                        PostField.Shares,       PostField.Reactions
                    };
                }
                return _defaultPostFields;
            }
        }

        public static void Serialize(IEnumerable<PageField> pageFields, StringBuilder stringBuilder)
        {
            IEnumerable<PageField> fields = pageFields ?? DefaultPageFields;

            stringBuilder.Append("fields=");
            foreach (PageField field in pageFields)
            {
                switch (field)
                {
                    case PageField.Id:
                        stringBuilder.Append("id");
                        break;
                    case PageField.Name:
                        stringBuilder.Append("name");
                        break;
                    case PageField.FanCount:
                        stringBuilder.Append("fan_count");
                        break;
                    case PageField.Category:
                        stringBuilder.Append("category");
                        break;
                }

                stringBuilder.Append(',');
            }
        }

        public static void Serialize(IEnumerable<PostField> postFields, StringBuilder stringBuilder)
        {
            IEnumerable<PostField> fields = postFields ?? DefaultPostFields;

            stringBuilder.Append("fields=");
            foreach (PostField field in fields)
            {
                switch (field)
                {
                    case PostField.Id:
                        stringBuilder.Append("id");
                        break;
                    case PostField.Message:
                        stringBuilder.Append("message");
                        break;
                    case PostField.Link:
                        stringBuilder.Append("link");
                        break;
                    case PostField.Caption:
                        stringBuilder.Append("caption");
                        break;
                    case PostField.Description:
                        stringBuilder.Append("description");
                        break;
                    case PostField.Poster:
                        stringBuilder.Append("from");
                        break;
                    case PostField.Created:
                        stringBuilder.Append("created_time");
                        break;
                    case PostField.Updated:
                        stringBuilder.Append("updated_time");
                        break;
                    case PostField.Permalink:
                        stringBuilder.Append("permalink_url");
                        break;
                    case PostField.StatusType:
                        stringBuilder.Append("status_type");
                        break;
                    case PostField.CallToAction:
                        stringBuilder.Append("call_to_action");
                        break;
                    case PostField.Type:
                        stringBuilder.Append("type");
                        break;
                    case PostField.Name:
                        stringBuilder.Append("name");
                        break;
                    case PostField.Place:
                        stringBuilder.Append("place");
                        break;
                    case PostField.Comments:
                        stringBuilder.Append("comments.limit(0).summary(true)");
                        break;
                    case PostField.Shares:
                        stringBuilder.Append("shares");
                        break;
                    case PostField.Reactions:
                        stringBuilder.Append("reactions.limit(0).summary(true)");
                        break;
                }

                stringBuilder.Append(',');
            }
        }
    }
}
