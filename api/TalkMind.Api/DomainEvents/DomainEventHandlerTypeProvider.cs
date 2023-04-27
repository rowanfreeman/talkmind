using System.Reflection;

namespace TalkMind.Api.DomainEvents;

public static class DomainEventHandlerTypeProvider
{
    private static Lazy<IReadOnlyDictionary<Type, IReadOnlyCollection<Type>>> _handlers =
        new(() =>
        {
            var dictionary = new Dictionary<Type, IReadOnlyCollection<Type>>();

            var domainHandlerTypes = GetDomainEventHandlerDescriptors(
                typeof(DomainEventHandlerTypeProvider).Assembly
            );

            var groups = domainHandlerTypes.GroupBy(x => x.DomainEventType);

            foreach (var group in groups)
                dictionary.TryAdd(group.Key, group.Select(x => x.DomainEventHandlerType).ToArray());

            return dictionary;
        });

    public static IReadOnlyCollection<Type> GetDomainEventHandlerTypes() =>
        _handlers.Value.SelectMany(x => x.Value).ToArray();

    public static IReadOnlyCollection<Type> GetDomainEventHandlerTypes<TDomainEvent>(
        TDomainEvent domainEvent
    )
        where TDomainEvent : notnull => GetDomainEventHandlerTypes(domainEvent.GetType());

    public static IReadOnlyCollection<Type> GetDomainEventHandlerTypes(Type domainEventType)
    {
        var handlers = _handlers.Value;

        return handlers.GetValueOrDefault(domainEventType) ?? Array.Empty<Type>();
    }

    private static IReadOnlyCollection<DomainEventHandlerDescriptor> GetDomainEventHandlerDescriptors(
        Assembly assembly
    )
    {
        var types = assembly.GetTypes();

        var domainEventHandlerTypes = types
            .Where(x => x.IsPublic && x.IsClass && !x.IsAbstract)
            .Select(
                x =>
                    new
                    {
                        DomainEventType = ImplementsIDomainEventHandler(x),
                        DomainEventHandlerType = x
                    }
            )
            .Where(x => x.DomainEventType is not null)
            .Select(
                x => new DomainEventHandlerDescriptor(x.DomainEventHandlerType, x.DomainEventType!)
            );

        return domainEventHandlerTypes.ToArray();
    }

    private static Type? ImplementsIDomainEventHandler(Type type) =>
        type.GetInterfaces()
            .FirstOrDefault(
                x =>
                    x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>)
            )
            ?.GenericTypeArguments.FirstOrDefault();
}
