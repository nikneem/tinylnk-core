using System.Text.Json;
using TinyLink.Core.Abstractions.Commands;

namespace TinyLink.Core.Commands.CommandMessages;

public record ProcessHitCommand(
    string ShortCode,
    DateTimeOffset CreatedOn) : IUrlShortnerCommand
{
}
