using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

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
