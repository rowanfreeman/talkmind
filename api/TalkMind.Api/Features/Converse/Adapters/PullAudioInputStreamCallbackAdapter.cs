using Microsoft.CognitiveServices.Speech.Audio;

namespace TalkMind.Api.Features.Converse.Adapters;

public class PullAudioInputStreamCallbackAdapter : PullAudioInputStreamCallback
{
    private readonly Func<byte[], uint, int> _callback;

    public PullAudioInputStreamCallbackAdapter(Func<byte[], uint, int> callback) =>
        _callback = callback;

    public override int Read(byte[] dataBuffer, uint size) => _callback(dataBuffer, size);
}