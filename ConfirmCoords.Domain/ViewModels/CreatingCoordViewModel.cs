using ConfirmCoords.Domain.Models;

namespace ConfirmCoords.Domain.ViewModels
{
    public record CreatingCoordViewModel(decimal Longitude, decimal Latitude, string Details, User User);
}
