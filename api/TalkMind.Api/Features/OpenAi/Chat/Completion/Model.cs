using System.Runtime.Serialization;

namespace TalkMind.Api.Features.OpenAi.Chat.Completion;

public enum Model
{
    [EnumMember(Value = "gpt-4")]
    GPT_4,

    [EnumMember(Value = "gpt-4-0314")]
    GPT_4_0314,

    [EnumMember(Value = "gpt-4-32k")]
    GPT_4_32k,

    [EnumMember(Value = "gpt-4-32k-0314")]
    GPT_4_32k_0314,

    [EnumMember(Value = "gpt-3.5-turbo")]
    GPT_3_5_Turbo,

    [EnumMember(Value = "gpt-3.5-turbo-0301")]
    GPT_3_5_Turbo_0301,
}
