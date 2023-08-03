using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TinyLink.Core.Configuration;

namespace TinyLink.Core.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTinyLinksCore(this IServiceCollection services, IConfiguration configuration)
    {
        var configurationSection = configuration.GetSection(AzureCloudConfiguration.SectionName);

        services.AddOptions<AzureCloudConfiguration>()
            .Bind(configuration.GetSection(AzureCloudConfiguration.SectionName))
            .ValidateOnStart();

        services.AddApplicationInsightsTelemetry();

        return services;
    }
}