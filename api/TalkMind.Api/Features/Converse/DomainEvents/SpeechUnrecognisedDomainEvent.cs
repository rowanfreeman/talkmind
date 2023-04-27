using TalkMind.Api.Features.Converse.Proxies;

namespace TalkMind.Api.Features.Converse.DomainEvents;

public sealed record SpeechUnrecognisedDomainEvent
{
    internal SpeechUnrecognisedDomainEvent(
        ISpeechRecognitionResultProxy speechRecognitionResult,
        string connectionId
    )
    {
        SpeechRecognitionResult = speechRecognitionResult;
        ConnectionId = connectionId;
    }

    internal ISpeechRecognitionResultProxy SpeechRecognitionResult { get; }

    internal string ConnectionId { get; }
}