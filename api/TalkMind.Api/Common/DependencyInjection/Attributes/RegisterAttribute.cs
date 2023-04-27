namespace TalkMind.Api.Common.DependencyInjection.Attributes;

public class RegisterAttribute : Attribute
{
    protected RegisterAttribute() => ServiceLifetime = ServiceLifetime.Transient;

    protected RegisterAttribute(ServiceLifetime serviceLifetime) =>
        ServiceLifetime = serviceLifetime;

    public ServiceLifetime ServiceLifetime { get; }
}

public class RegisterAttribute<TInterface> : RegisterAttribute
{
    public RegisterAttribute()
        : base() { }

    public RegisterAttribute(ServiceLifetime serviceLifetime)
        : base(serviceLifetime) { }
}