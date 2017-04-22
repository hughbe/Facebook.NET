using System;
using Newtonsoft.Json;

namespace Facebook.Models
{
    public class Comment
    {
        public string Id { get; set; }

        public string Message { get; set; }

        [JsonProperty(PropertyName = "from")]
        public User Poster { get; set; }

        [JsonProperty(PropertyName = "like_count")]
        public int NumberOfLikes { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int NumberOfReplies { get; set; }

        public Comment ParentComment { get; set; }

        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty(PropertyName = "updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
