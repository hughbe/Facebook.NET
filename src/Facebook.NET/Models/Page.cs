using Newtonsoft.Json;

namespace Facebook.Models
{
    public class Page
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "fan_count")]
        public int FanCount { get; set; }

        public string Category { get; set; }

        public override string ToString() => Name;
    }
}
