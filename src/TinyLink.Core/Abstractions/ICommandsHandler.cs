using TinyLink.Core.Commands;

namespace TinyLink.Core.Abstractions;

public interface ICommandsHandler
{
    Task<string> Send(IUrlShortnerCommand command, string queueName, CancellationToken cancellationToken = default);
}