namespace ConfirmCoords.Domain.ViewModels
{
    public record CreatingCoordResultViewModel(bool IsCreated, int? Id, string? ErrorMessage = null);
}
