using Azure.Messaging.ServiceBus;

namespace TinyLink.Core.Abstractions.Commands;

public interface ICommandsSenderFactory
{
    Task<long> Send(IUrlShortnerCommand command, string queueOrTopicName, CancellationToken cancellationToken = default);
    ServiceBusSender CreateSender(string queueOrTopicName);
}