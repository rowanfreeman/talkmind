namespace TalkMind.Api.Configuration.Options;

public sealed record OpenAiOptions
{
    public string ApiKey { get; init; } = string.Empty;

    public string BaseUri { get; init; } = string.Empty;

    public string ChatCompletionsUri { get; init; } = string.Empty;
}
