using Microsoft.CognitiveServices.Speech;

namespace TalkMind.Api.Features.Converse.Proxies;

public interface ISpeechRecognitionResultProxy
{
    string ResultId { get; }

    ResultReason Reason { get; }

    string Text { get; }

    TimeSpan Duration { get; }

    long OffsetInTicks { get; }

    PropertyCollection Properties { get; }
}