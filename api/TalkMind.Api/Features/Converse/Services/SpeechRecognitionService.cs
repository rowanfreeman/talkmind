using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Options;
using TalkMind.Api.Common.DependencyInjection.Attributes;
using TalkMind.Api.Configuration.Options;
using TalkMind.Api.Features.Converse.Factories;
using TalkMind.Api.Features.Converse.Proxies;

namespace TalkMind.Api.Features.Converse.Services;

[Register<ISpeechRecognitionService>]
public sealed class SpeechRecognitionService : ISpeechRecognitionService
{
    private readonly AzureCognitiveServicesOptions _cognitiveServicesOptions;
    private readonly ILogger<SpeechRecognitionService> _logger;

    public SpeechRecognitionService(
        IOptions<AzureCognitiveServicesOptions> options,
        ILogger<SpeechRecognitionService> logger
    )
    {
        _cognitiveServicesOptions = options.Value;
        _logger = logger;
    }

    public async Task<ISpeechRecognitionResultProxy> Recognise(
        IPullAudioInputStreamFactory pullAudioInputStreamFactory,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var speechConfig = SpeechConfig.FromSubscription(
                _cognitiveServicesOptions.SubscriptionKey,
                _cognitiveServicesOptions.Region
            );

            using var audioInputStream = pullAudioInputStreamFactory.Create();

            using var audioConfig = AudioConfig.FromStreamInput(audioInputStream);
            using var recogniser = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recogniser.RecognizeOnceAsync();
            return new SpeechRecognitionResultProxy(result);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            throw;
        }
    }
}