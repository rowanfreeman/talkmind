using Microsoft.CognitiveServices.Speech.Audio;

namespace TalkMind.Api.Features.Converse.Factories;

public interface IPullAudioInputStreamFactory
{
    PullAudioInputStream Create();
}