using Microsoft.AspNetCore.SignalR;
using Microsoft.CognitiveServices.Speech;
using NAudio.Wave;
using System.Runtime.InteropServices;
using TalkMind.Api.Converters;
using TalkMind.Api.DomainEvents;
using TalkMind.Api.Features.Converse.DomainEvents;
using TalkMind.Api.Features.Converse.Factories;
using TalkMind.Api.Features.Converse.Services;

namespace TalkMind.Api.Features.Converse.Hubs;

public sealed class ConverseHub : Hub
{
    private readonly ISpeechRecognitionService _speechRecognitionService;
    private readonly ILogger<ConverseHub> _logger;
    private readonly IEventBus _eventBus;

    public ConverseHub(
        ISpeechRecognitionService speechRecognitionService,
        ILogger<ConverseHub> logger,
        IEventBus eventBus
    )
    {
        _speechRecognitionService = speechRecognitionService;
        _logger = logger;
        _eventBus = eventBus;
    }

    public async Task Converse(string data)
    {
        _logger.LogDebug("Base64 to be decoded: {data}", data);

        var audioBytes = Base64Converter.GetBytes(data);

        if (audioBytes is null)
        {
            var error = "Unable to decode audio.";
            _logger.LogError(error, data);
            var speechErrorDomainEvent = new SpeechErrorDomainEvent(Context.ConnectionId, error);
            await _eventBus.Publish(speechErrorDomainEvent);

            return;
        }

        _logger.LogDebug("Data successfully decoded into bytes.");

        using var webmStream = new MemoryStream(audioBytes);

        try
        {
            using var webmReader = new StreamMediaFoundationReader(webmStream);

            _logger.LogDebug("Audio appears to be valid Media Foundation (webm).");

            var factory = new MediaFoundationPullAudioInputStreamFactory(webmReader);
            var result = await _speechRecognitionService.Recognise(
                factory,
                Context.ConnectionAborted
            );

            switch (result.Reason)
            {
                case ResultReason.RecognizedSpeech:
                    var speechRecognisedDomainEvent = new SpeechRecognisedDomainEvent(
                        result,
                        Context.ConnectionId
                    );
                    await _eventBus.Publish(speechRecognisedDomainEvent);
                    break;

                default:
                    var speechUnrecognisedDomainEvent = new SpeechUnrecognisedDomainEvent(
                        result,
                        Context.ConnectionId
                    );
                    await _eventBus.Publish(speechUnrecognisedDomainEvent);
                    break;
            }
        }
        catch (COMException exception)
        {
            _logger.LogError(exception, exception.Message);

            var speechErrorDomainEvent = new SpeechErrorDomainEvent(
                Context.ConnectionId,
                "Unable to decode audio."
            );
            await _eventBus.Publish(speechErrorDomainEvent);
        }
    }
}