using System.Text.Json;
using TinyLink.Core.Abstractions.Commands;

namespace TinyLink.Core.Commands.CommandMessages;

public record ProcessHitCommand(
    Guid Id,
    string ShortCode,
    string OwnerId,
    DateTimeOffset CreatedOn) : IUrlShortnerCommand
{
}
