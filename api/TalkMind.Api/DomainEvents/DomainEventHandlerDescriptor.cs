namespace TalkMind.Api.DomainEvents;

public sealed record DomainEventHandlerDescriptor
{
    public DomainEventHandlerDescriptor(Type domainEventHandlerType, Type domainEventType)
    {
        DomainEventHandlerType = domainEventHandlerType;
        DomainEventType = domainEventType;
    }

    public Type DomainEventHandlerType { get; }

    public Type DomainEventType { get; }
}
