using TalkMind.Api.Features.Converse.Factories;
using TalkMind.Api.Features.Converse.Proxies;

namespace TalkMind.Api.Features.Converse.Services;

public interface ISpeechRecognitionService
{
    Task<ISpeechRecognitionResultProxy> Recognise(
        IPullAudioInputStreamFactory pullAudioInputStreamFactory,
        CancellationToken cancellationToken = default
    );
}