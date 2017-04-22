using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CommentOrder
    {
        Ranked,
        Chronological,
        [EnumMember(Value = "reverse_chronological")]
        ReverseChronological
    }
}
