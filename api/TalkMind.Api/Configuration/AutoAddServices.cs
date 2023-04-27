using System.Reflection;

namespace TalkMind.Api.Configuration;

[Obsolete]
public static class AutoAddServices
{
    public static IServiceCollection AddServicesFrom<T>(this IServiceCollection services)
    {
        var assembly = typeof(T).Assembly;
        var interfacesAndClassImplementationMap = GetAllInterfacesAndClassImplementationMap(
            assembly
        );

        var publicClasses = assembly.GetTypes().Where(x => x.IsPublic && x.IsClass).ToArray();
        foreach (var @class in publicClasses)
        {
            var constructors = @class.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                foreach (var parameter in parameters)
                {
                    var parameterType = parameter.ParameterType;
                    interfacesAndClassImplementationMap.TryGetValue(
                        parameterType,
                        out var interfaceToRegister
                    );

                    if (interfaceToRegister is not null)
                        services.AddTransient(parameterType, interfaceToRegister);
                }
            }
        }

        return services;
    }

    private static IReadOnlyDictionary<Type, Type> GetAllInterfacesAndClassImplementationMap(
        Assembly assembly
    )
    {
        var interfaces = assembly.GetTypes().Where(x => x.IsPublic && x.IsInterface);
        var classes = assembly.GetTypes().Where(x => x.IsPublic && x.IsClass);
        var interfacesMap = new Dictionary<Type, Type>();

        foreach (var @interface in interfaces)
        {
            var implementation = classes.FirstOrDefault(x => @interface.IsAssignableFrom(x));
            if (implementation is not null)
                interfacesMap.Add(@interface, implementation);
        }

        return interfacesMap;
    }
}