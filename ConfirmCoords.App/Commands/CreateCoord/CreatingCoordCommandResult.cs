using ConfirmCoords.Domain.Models;

namespace ConfirmCoords.App.Commands.CreateCoord
{
    public record CreatingCoordCommandResult(bool IsCreated, CoordDetails? Data, string? ErrorMessage);
}
