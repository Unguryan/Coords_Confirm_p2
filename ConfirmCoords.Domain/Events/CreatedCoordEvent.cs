using ConfirmCoords.Domain.Events;

namespace Coord.Domain.Events
{
    public record CreatedCoordEvent (bool IsCreated, int? Id, string? ErrorMessage = null) : IBaseEvent;
}
