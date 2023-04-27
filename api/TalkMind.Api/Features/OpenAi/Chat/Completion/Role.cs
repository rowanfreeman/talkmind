using System.Runtime.Serialization;

namespace TalkMind.Api.Features.OpenAi.Chat.Completion;

public enum Role
{
    /// <value>Represents responses from OpenAI; i.e. the assistant that the user is conversing with.</value>
    [EnumMember(Value = "assistant")]
    Assistant,

    /// <value>Represents the beginning of a conversation.</value>
    [EnumMember(Value = "system")]
    System,

    /// <value>Represents requests from the user that is conversing with OpenAI.</value>
    [EnumMember(Value = "user")]
    User,
}
