namespace TalkMind.Api.DomainEvents;

public interface IDomainEventHandler<in TDomainEvent>
{
    Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken);
}
