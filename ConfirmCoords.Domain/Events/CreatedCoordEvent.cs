using ConfirmCoords.Domain.Events;
using ConfirmCoords.Domain.Models;

namespace Coord.Domain.Events
{
    public record CreatedCoordEvent (bool IsCreated, CoordDetails? Data, string? ErrorMessage = null) : IBaseEvent;
}
