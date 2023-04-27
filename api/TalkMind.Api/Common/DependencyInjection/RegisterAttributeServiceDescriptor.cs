namespace TalkMind.Api.Common.DependencyInjection;

internal record RegisterAttributeServiceDescriptor(
    Type Interface,
    Type Implementation,
    ServiceLifetime ServiceLifetime
)
{ }