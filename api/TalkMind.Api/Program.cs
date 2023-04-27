using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using TalkMind.Api.Common.DependencyInjection;
using TalkMind.Api.Configuration.Options;
using TalkMind.Api.DomainEvents.Extensions;
using TalkMind.Api.Features.Converse.Hubs;
using TalkMind.Api.Features.OpenAi.Chat;
using TalkMind.Api.JsonConverters;

namespace TalkMind.Api;

public sealed class Program
{
    private const string _primaryCorsPolicy = "DevCorsPolicy";

    public static void Main(string[] args)
    {
        var builder = CreateBuilder(args);

        var app = builder.Build();
        app.UseCors(_primaryCorsPolicy);
        app.MapHub<ConverseHub>("/hubs/converse");

        app.Run();
    }

    public static WebApplicationBuilder CreateBuilder(params string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.AddConsole();

        ConfigureServices(builder.Services, builder.Configuration);

        return builder;
    }

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        jsonSerializerOptions.Converters.Add(new JsonStringEnumMemberConverter());

        services.AddSignalR(options => options.MaximumReceiveMessageSize = long.MaxValue);

        services.AddCors(options =>
        {
            var uiUrl = configuration.GetValue<string>("UiUrl") ?? "";
            options.AddPolicy(
                _primaryCorsPolicy,
                policy => policy.AllowCredentials().AllowAnyHeader().WithOrigins(uiUrl)
            );
        });

        services.AddAllOptions();
        services.AddTalkMind();
        services.AddHttpClient<IOpenAiChatClient, OpenAiChatClient>(
            (provider, client) =>
            {
                var options = provider.GetRequiredService<IOptions<OpenAiOptions>>();
                client.BaseAddress = new(options.Value.BaseUri);
                client.DefaultRequestHeaders.Authorization = new("Bearer", options.Value.ApiKey);
                client.DefaultRequestVersion = new(3, 0);
            }
        );

        services.AddHttpContextAccessor();
        services.AddDomainEventHandlers();

        services.AddSingleton(jsonSerializerOptions);
    }
}