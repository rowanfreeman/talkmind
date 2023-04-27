using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.Wave;
using TalkMind.Api.Features.Converse.Adapters;

namespace TalkMind.Api.Features.Converse.Factories;

public sealed class MediaFoundationPullAudioInputStreamFactory : IPullAudioInputStreamFactory
{
    private readonly StreamMediaFoundationReader _streamMediaFoundationReader;

    public MediaFoundationPullAudioInputStreamFactory(
        StreamMediaFoundationReader streamMediaFoundationReader
    ) => _streamMediaFoundationReader = streamMediaFoundationReader;

    public PullAudioInputStream Create()
    {
        var sampleProvider = _streamMediaFoundationReader.ToSampleProvider();
        var monoProvider = sampleProvider.ToMono().ToWaveProvider();

        using var format = AudioStreamFormat.GetWaveFormatPCM(
            Convert.ToUInt32(monoProvider.WaveFormat.SampleRate),
            Convert.ToByte(monoProvider.WaveFormat.BitsPerSample),
            1
        );

        var audioInputStream = AudioInputStream.CreatePullStream(
            new PullAudioInputStreamCallbackAdapter(
                (buffer, size) =>
                {
                    var offset = 0;
                    var count = Convert.ToInt32(size);
                    return monoProvider.Read(buffer, offset, count);
                }
            ),
            format
        );

        return audioInputStream;
    }
}
