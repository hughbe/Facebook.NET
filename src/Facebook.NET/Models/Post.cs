using System;
using Newtonsoft.Json;

namespace Facebook.Models
{
    public class Post
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty(PropertyName = "updated_time")]
        public DateTime UpdatedTime { get; set; }

        public string Message { get; set; }

        public string Link { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        [JsonProperty(PropertyName = "permalink_url")]
        public string Permalink { get; set; }

        public PostType Type { get; set; }

        [JsonProperty(PropertyName = "status_type")]
        public StatusUpdateType StatusType { get; set; }

        public string Name { get; set; }

        private Comments _comments;
        public Comments Comments
        {
            get => _comments ?? (_comments = new Comments());
            set => _comments = value;
        }

        private Reactions _reactions;
        public Reactions Reactions
        {
            get => _reactions ?? (_reactions = new Reactions());
            set => _reactions = value;
        }

        private Shares _shares;
        public Shares Shares
        {
            get => _shares ?? (_shares = new Shares());
            set => _shares = value;
        }

        [JsonProperty(PropertyName = "call_to_action")]
        public CallToAction CallToAction { get; set; }

        [JsonProperty(PropertyName = "from")]
        public Profile Poster { get; set; }

        public Place Place { get; set; }
    }
}
