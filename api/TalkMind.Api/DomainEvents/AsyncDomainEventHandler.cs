namespace TalkMind.Api.DomainEvents;

public abstract class AsyncDomainEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent>
{
    protected abstract void Handle(TDomainEvent domainEvent);

    Task IDomainEventHandler<TDomainEvent>.Handle(
        TDomainEvent domainEvent,
        CancellationToken cancellationToken
    )
    {
        Handle(domainEvent);

        return Task.CompletedTask;
    }
}
