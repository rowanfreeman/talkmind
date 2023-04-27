namespace TalkMind.Api.Extensions;

internal static class ILoggerExtensions
{
    internal static IDisposable? CreateScope(this ILogger logger, string? correlationId = null)
    {
        correlationId ??= Guid.NewGuid().ToString();
        var scope = logger.BeginScope("test", (nameof(correlationId), correlationId));

        return scope;
    }
}