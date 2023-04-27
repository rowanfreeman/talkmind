using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TalkMind.Api.DomainEvents.Extensions;

internal static class DomainEventHandlerServiceProvider
{
    internal static IServiceCollection AddDomainEventHandlers(this IServiceCollection services)
    {
        var handlers = DomainEventHandlerTypeProvider.GetDomainEventHandlerTypes();

        foreach (var handler in handlers)
            services.TryAddTransient(handler);

        return services;
    }
}
