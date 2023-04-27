using Microsoft.AspNetCore.SignalR;
using TalkMind.Api.DomainEvents;
using TalkMind.Api.Features.Converse.DomainEvents;
using TalkMind.Api.Features.Converse.Hubs;

namespace TalkMind.Api.Features.Converse.Handlers;

public sealed class SpeechErrorDomainEventHandler : IDomainEventHandler<SpeechErrorDomainEvent>
{
    private readonly IHubContext<ConverseHub> _hubContext;

    public SpeechErrorDomainEventHandler(IHubContext<ConverseHub> hubContext) =>
        _hubContext = hubContext;

    public async Task Handle(
        SpeechErrorDomainEvent domainEvent,
        CancellationToken cancellationToken
    )
    {
        var client = _hubContext.Clients.Client(domainEvent.ConnectionId);

        await client.SendAsync("SpeechError", domainEvent.Message, cancellationToken);
    }
}