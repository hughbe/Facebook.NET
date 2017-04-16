using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostType
    {
        Link,
        Status,
        Photo,
        Video,
        Offer,
        Event
    }
}
