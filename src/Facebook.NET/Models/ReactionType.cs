using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ReactionType
    {
        None,
        Like,
        Wow,
        Haha,
        Sad,
        Angry,
        Thankful
    }
}