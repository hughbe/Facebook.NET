using System.Text;

namespace Facebook.Requests
{
    public class PostsRequest : PagedRequest
    {
        public string PageId { get; set; }
        public PostsRequestEdge Edge { get; set; }
        
        private const string Fields = "message,link,caption,description,from,created_time,updated_time,permalink_url,status_type,call_to_action,type,name,place,id,comments.limit(0).summary(true),shares,reactions.limit(0).summary(true)";

        internal override void Format(StringBuilder builder)
        {
            builder.AppendFormat("fields={0}&", Fields);
            base.Format(builder);
        }
    }
}
