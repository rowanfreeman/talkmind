using TalkMind.Api.Common.DependencyInjection.Attributes;

namespace TalkMind.Api.DomainEvents;

[Register<IEventBus>]
public sealed class EventBus : IEventBus
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EventBus(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
    {
        _serviceProvider = serviceProvider;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Publish<TDomainEvent>(TDomainEvent domainEvent)
        where TDomainEvent : notnull
    {
        var handlerTypes = DomainEventHandlerTypeProvider.GetDomainEventHandlerTypes(domainEvent);

        var tasks = new List<Task>();
        var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? default;

        foreach (var handlerType in handlerTypes)
        {
            var handler = (
                _serviceProvider.GetRequiredService(handlerType)
                as IDomainEventHandler<TDomainEvent>
            )!;

            tasks.Add(handler.Handle(domainEvent, cancellationToken));
        }

        await Task.WhenAll(tasks);
    }
}