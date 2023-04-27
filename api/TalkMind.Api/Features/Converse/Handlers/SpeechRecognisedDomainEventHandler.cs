using Microsoft.AspNetCore.SignalR;
using TalkMind.Api.Common.DependencyInjection.Attributes;
using TalkMind.Api.DomainEvents;
using TalkMind.Api.Features.Converse.DomainEvents;
using TalkMind.Api.Features.Converse.Hubs;
using TalkMind.Api.Features.OpenAi;
using TalkMind.Api.Features.OpenAi.Chat.Completion;

namespace TalkMind.Api.Features.Converse.Handlers;

[Register<IDomainEventHandler<SpeechRecognisedDomainEvent>>]
public sealed class SpeechRecognisedDomainEventHandler
    : IDomainEventHandler<SpeechRecognisedDomainEvent>
{
    private readonly IOpenAiApi _openAiApi;
    private readonly ILogger<SpeechRecognisedDomainEventHandler> _logger;
    private readonly IHubContext<ConverseHub> _hubContext;

    public SpeechRecognisedDomainEventHandler(
        IOpenAiApi openAiApi,
        ILogger<SpeechRecognisedDomainEventHandler> logger,
        IHubContext<ConverseHub> hubContext
    )
    {
        _openAiApi = openAiApi;
        _logger = logger;
        _hubContext = hubContext;
    }

    public async Task Handle(
        SpeechRecognisedDomainEvent domainEvent,
        CancellationToken cancellationToken
    )
    {
        var result = domainEvent.SpeechRecognitionResult;

        await _hubContext.Clients
            .Client(domainEvent.ConnectionId)
            .SendAsync("SpeechRecognised", result.Text, cancellationToken);

        var messages = new Message[] { new() { Content = result.Text } };
        var chatCompletionRequest = new Request(Model.GPT_3_5_Turbo, messages)
        {
            User = domainEvent.ConnectionId,
        };

        var response = await _openAiApi.Chat.CreateCompletion(
            chatCompletionRequest,
            cancellationToken
        );

        // todo
    }
}
