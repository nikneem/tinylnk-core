using Azure.Storage.Queues;
using Microsoft.Extensions.Options;
using TinyLink.Core.Abstractions;
using TinyLink.Core.Configuration;
using TinyLink.Core.Helpers;

namespace TinyLink.Core.Commands;

public class UrlShortnerCommands : ICommandsHandler
{
    private readonly QueueServiceClient _queueServiceClient;

    public async Task<string> Send(IUrlShortnerCommand command, string queueName, CancellationToken cancellationToken = default)
    {
        var queueClient = _queueServiceClient.GetQueueClient(queueName);
        var binaryMessage = command.ToBinaryData();
        var response = await queueClient.SendMessageAsync(binaryMessage, cancellationToken: cancellationToken);
        return response.Value.MessageId;
    }

    public UrlShortnerCommands(IOptions<AzureCloudConfiguration> configuration)
    {
        var identity = CloudIdentity.GetChainedTokenCredential();
        var storageAccountUrl = new Uri($"https://{configuration.Value.StorageAccountName}.queue.core.windows.net");
        _queueServiceClient = new QueueServiceClient(storageAccountUrl, identity);
    }
}