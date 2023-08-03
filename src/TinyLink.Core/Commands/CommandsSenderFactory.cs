using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TinyLink.Core.Abstractions.Commands;
using TinyLink.Core.Configuration;
using TinyLink.Core.ExtensionMethods;
using TinyLink.Core.Helpers;

namespace TinyLink.Core.Commands;

public class CommandsSenderFactory : ICommandsSenderFactory
{
    private readonly IOptions<AzureCloudConfiguration> _options;
    private readonly ILogger<CommandsSenderFactory> _logger;

    private readonly Lazy<ServiceBusClient> _serviceBusClient;

    public async Task<long> Send(IUrlShortnerCommand command, string queueName, CancellationToken cancellationToken = default)
    {
        var sender = CreateSender(queueName);
        var message = command.ToServiceBusMessage();
        return await sender.ScheduleMessageAsync(message, DateTimeOffset.UtcNow, cancellationToken);
    }

    public ServiceBusSender CreateSender(string queueOrTopicName)
    {
        _logger.LogInformation("Creating new service bus sender for topic or queue name {queueOrTopicName}", queueOrTopicName);
        return _serviceBusClient.Value.CreateSender(queueOrTopicName);
    }

    private ServiceBusClient CreateServiceBusClient()
    {
        var identity = CloudIdentity.GetChainedTokenCredential();
        var serviceBusFqdn = $"{_options.Value.ServiceBusName}.servicebus.windows.net";
        return new ServiceBusClient(serviceBusFqdn, identity);
    }

    public CommandsSenderFactory(
        IOptions<AzureCloudConfiguration> options, 
        ILogger<CommandsSenderFactory> logger)
    {
        _options = options;
        _logger = logger;
        _serviceBusClient = new Lazy<ServiceBusClient>(CreateServiceBusClient);
    }

}