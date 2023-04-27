using System.Text.Json.Serialization;
using TalkMind.Api.JsonConverters;

namespace TalkMind.Api.Features.OpenAi.Chat.Completion;

public record Response
{
    public string? Id { get; init; }

    public string? Object { get; init; }

    [JsonConverter(typeof(JavascriptEpochDateTimeOffsetConverter))]
    public DateTimeOffset? Created { get; init; }

    public Model? Model { get; init; }

    public Usage? Usage { get; init; }

    public IReadOnlyCollection<Choice>? Choices { get; init; }
}
