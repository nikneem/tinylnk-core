using TinyLink.Core.Abstractions.Commands;

namespace TinyLink.Core.Commands.CommandMessages;

public record TotalHitsChangedCommand(
        Guid Id,
        string ShortCode,
        string OwnerId,
        int TotalHits) : IUrlShortnerCommand;
