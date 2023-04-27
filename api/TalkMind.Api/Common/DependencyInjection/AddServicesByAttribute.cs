using System.Reflection;
using TalkMind.Api.Common.DependencyInjection.Attributes;

namespace TalkMind.Api.Common.DependencyInjection;

internal static class AddServicesByAttribute
{
    private static readonly Type _registerAttributeType = typeof(RegisterAttribute<>);
    private static readonly Assembly _assembly = _registerAttributeType.Assembly;

    internal static IServiceCollection AddTalkMind(this IServiceCollection services)
    {
        var serviceDescriptors = _assembly
            .GetTypes()
            .Where(x => x.IsPublic && x.IsClass)
            .Select(GetServiceDescriptor)
            .Where(x => x is not null)
            .ToArray();

        foreach (var serviceDescriptor in serviceDescriptors)
            services.Add(
                new(
                    serviceDescriptor!.Interface,
                    serviceDescriptor.Implementation,
                    serviceDescriptor.ServiceLifetime
                )
            );

        return services;
    }

    private static RegisterAttributeServiceDescriptor? GetServiceDescriptor(Type type)
    {
        var maybeRegisterAttribute = type.GetCustomAttributes(_registerAttributeType, false)
            .FirstOrDefault();

        if (maybeRegisterAttribute is RegisterAttribute registerAttribute)
        {
            var registerAttributeType = registerAttribute.GetType();
            var interfaceType = registerAttributeType.GenericTypeArguments.First();

            return new(interfaceType, type, registerAttribute.ServiceLifetime);
        }

        return null;
    }
}