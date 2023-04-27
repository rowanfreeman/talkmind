using Microsoft.AspNetCore.SignalR;
using TalkMind.Api.DomainEvents;
using TalkMind.Api.Features.Converse.DomainEvents;
using TalkMind.Api.Features.Converse.Hubs;

namespace TalkMind.Api.Features.Converse.Handlers;

public sealed class SpeechUnrecognisedDomainEventHandler
    : IDomainEventHandler<SpeechUnrecognisedDomainEvent>
{
    private readonly IHubContext<ConverseHub> _hubContext;

    public SpeechUnrecognisedDomainEventHandler(IHubContext<ConverseHub> hubContext) =>
        _hubContext = hubContext;

    public async Task Handle(
        SpeechUnrecognisedDomainEvent domainEvent,
        CancellationToken cancellationToken
    )
    {
        var client = _hubContext.Clients.Client(domainEvent.ConnectionId);

        await client.SendAsync("SpeechUnrecognised", cancellationToken);
    }
}