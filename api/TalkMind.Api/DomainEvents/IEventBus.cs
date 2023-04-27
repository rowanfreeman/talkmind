namespace TalkMind.Api.DomainEvents;

public interface IEventBus
{
    Task Publish<TDomainEvent>(TDomainEvent domainEvent)
        where TDomainEvent : notnull;
}
