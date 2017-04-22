using System.Collections.Generic;
using System.Linq;
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

        private static IEnumerable<CommentField> _defaultCommentFields;
        private static IEnumerable<CommentField> DefaultCommentFields
        {
            get
            {
                if (_defaultCommentFields == null)
                {
                    _defaultCommentFields = new CommentField[]
                    {
                        CommentField.Id,              CommentField.Message,       CommentField.Poster,      CommentField.NumberOfLikes,
                        CommentField.NumberOfReplies, CommentField.ParentComment, CommentField.CreatedTime, CommentField.UpdatedTime
                    };
                }

                return _defaultCommentFields;
            }
        }

        public static void Serialize(IEnumerable<PageField> pageFields, StringBuilder stringBuilder)
        {
            PageField[] fields = (pageFields ?? DefaultPageFields).ToArray();

            stringBuilder.Append("fields=");
            for (int i = 0; i < fields.Length; i++)
            {
                PageField field = fields[i];
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

                if (i != fields.Length - 1)
                {
                    stringBuilder.Append(',');
                }
            }

            stringBuilder.Append("&");
        }

        public static void Serialize(IEnumerable<PostField> postFields, StringBuilder stringBuilder)
        {
            PostField[] fields = (postFields ?? DefaultPostFields).ToArray();

            stringBuilder.Append("fields=");
            for (int i = 0; i < fields.Length; i++)
            {
                PostField field = fields[i];
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

                if (i != fields.Length - 1)
                {
                    stringBuilder.Append(',');
                }
            }

            stringBuilder.Append("&");
        }

        public static void Serialize(IEnumerable<CommentField> commentFields, StringBuilder stringBuilder)
        {
            CommentField[] fields = (commentFields ?? DefaultCommentFields).ToArray();

            stringBuilder.Append("fields=");
            for (int i = 0; i < fields.Length; i++)
            {
                CommentField field = fields[i];
                switch (field)
                {
                    case CommentField.Id:
                        stringBuilder.Append("id");
                        break;
                    case CommentField.Message:
                        stringBuilder.Append("message");
                        break;
                    case CommentField.Poster:
                        stringBuilder.Append("from");
                        break;
                    case CommentField.NumberOfLikes:
                        stringBuilder.Append("like_count");
                        break;
                    case CommentField.NumberOfReplies:
                        stringBuilder.Append("comment_count");
                        break;
                    case CommentField.ParentComment:
                        stringBuilder.Append("parent");
                        break;
                    case CommentField.CreatedTime:
                        stringBuilder.Append("created_time");
                        break;
                    case CommentField.UpdatedTime:
                        stringBuilder.Append("updated_time");
                        break;
                }

                if (i != fields.Length - 1)
                {
                    stringBuilder.Append(',');
                }
            }

            stringBuilder.Append("&");
        }
    }
}
