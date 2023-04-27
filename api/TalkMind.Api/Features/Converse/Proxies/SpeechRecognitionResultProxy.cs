using Microsoft.CognitiveServices.Speech;

namespace TalkMind.Api.Features.Converse.Proxies;

public sealed record SpeechRecognitionResultProxy : ISpeechRecognitionResultProxy
{
    private readonly SpeechRecognitionResult _speechRecognitionResult;

    internal SpeechRecognitionResultProxy(SpeechRecognitionResult speechRecognitionResult) =>
        _speechRecognitionResult = speechRecognitionResult;

    public string ResultId => _speechRecognitionResult.ResultId;

    public ResultReason Reason => _speechRecognitionResult.Reason;

    public string Text => _speechRecognitionResult.Text;

    public TimeSpan Duration => _speechRecognitionResult.Duration;

    public long OffsetInTicks => _speechRecognitionResult.OffsetInTicks;

    public PropertyCollection Properties => _speechRecognitionResult.Properties;

    public override string ToString() => _speechRecognitionResult.ToString();

    public override int GetHashCode() => _speechRecognitionResult.GetHashCode();
}