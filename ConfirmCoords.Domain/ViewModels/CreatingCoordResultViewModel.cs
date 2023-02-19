using ConfirmCoords.Domain.Models;

namespace ConfirmCoords.Domain.ViewModels
{
    public record CreatingCoordResultViewModel(bool IsCreated, CoordDetails? Data, string? ErrorMessage = null);
}
