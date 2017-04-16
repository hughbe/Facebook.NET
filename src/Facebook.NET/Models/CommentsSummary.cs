using Newtonsoft.Json;

namespace Facebook.Models
{
    public class CommentsSummary
    {
        public CommentOrder Order { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        public override string ToString() => TotalCount.ToString();
    }
}
