using System.Text;

namespace Facebook.Requests
{
    public class PageRequest : Request
    {
        public string PageId { get; set; }

        private const string Fields = "id,name,fan_count";

        internal override void Format(StringBuilder builder)
        {
            builder.AppendFormat("fields={0}&", Fields);
        }
    }
}
