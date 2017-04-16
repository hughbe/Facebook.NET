using Newtonsoft.Json;

namespace Facebook.Models
{
    public class ReactionsSummary
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("viewer_reaction")]
        public ReactionType ViewerReaction { get; set; }

        public override string ToString() => TotalCount.ToString();
    }
}