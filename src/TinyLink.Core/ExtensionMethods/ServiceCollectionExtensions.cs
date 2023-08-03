using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TinyLink.Core.Abstractions.Commands;
using TinyLink.Core.Commands;
using TinyLink.Core.Configuration;

namespace TinyLink.Core.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTinyLinksCore(this IServiceCollection services, IConfiguration configuration)
    {
        // Adding configuration options with validation on startup

        services.AddOptions<AzureCloudConfiguration>()
            .Bind(configuration.GetSection(AzureCloudConfiguration.SectionName))
            .ValidateOnStart();

        services.AddScoped<ICommandsSenderFactory, CommandsSenderFactory>();

        services.AddApplicationInsightsTelemetry();

        return services;
    }
}