using TinyLink.Core.Abstractions.Commands;

namespace TinyLink.Core.Commands.CommandMessages;

public record ProcessHitCommand(
    Guid Id,
    string ShortCode,
    string OwnerId,
    string TotalHits,
    DateTimeOffset CreatedOn) : IUrlShortnerCommand
{
}
