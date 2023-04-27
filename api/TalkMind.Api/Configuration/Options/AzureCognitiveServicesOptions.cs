namespace TalkMind.Api.Configuration.Options;

public sealed record AzureCognitiveServicesOptions
{
    public string SubscriptionKey { get; init; } = string.Empty;

    public string Region { get; init; } = string.Empty;
}
