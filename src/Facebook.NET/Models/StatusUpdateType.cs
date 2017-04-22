using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Facebook.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusUpdateType
    {
        [EnumMember(Value = "mobile_status_update")]
        MobileStatusUpdate,
        [EnumMember(Value = "created_note")]
        CreatedNote,
        [EnumMember(Value = "added_photos")]
        AddedPhotos,
        [EnumMember(Value = "added_video")]
        AddedVideo,
        [EnumMember(Value = "shared_story")]
        SharedStory,
        [EnumMember(Value = "created_group")]
        CreatedGroup,
        [EnumMember(Value = "created_event")]
        CreatedEvent,
        [EnumMember(Value = "wall_post")]
        WallPoist,
        [EnumMember(Value = "app_created_story")]
        AppCreatedStory,
        [EnumMember(Value = "published_story")]
        PublishedStory,
        [EnumMember(Value = "tagged_in_photo")]
        TaggedInPhoto,
        [EnumMember(Value = "approved_friend")]
        ApprovedFriend
    }
}
