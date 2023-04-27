using System.Text.Json.Serialization;

namespace TalkMind.Api.Features.OpenAi.Chat.Completion;

public record Choice
{
    public Message? Message { get; init; }

    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; init; }

    public int Index { get; init; }
}
