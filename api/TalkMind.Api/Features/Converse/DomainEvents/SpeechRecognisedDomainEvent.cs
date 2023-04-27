using TalkMind.Api.Features.Converse.Proxies;

namespace TalkMind.Api.Features.Converse.DomainEvents;

public sealed record SpeechRecognisedDomainEvent
{
    public SpeechRecognisedDomainEvent(
        ISpeechRecognitionResultProxy speechRecognitionResult,
        string connectionId
    )
    {
        SpeechRecognitionResult = speechRecognitionResult;
        ConnectionId = connectionId;
    }

    public ISpeechRecognitionResultProxy SpeechRecognitionResult { get; }

    public string ConnectionId { get; }
}