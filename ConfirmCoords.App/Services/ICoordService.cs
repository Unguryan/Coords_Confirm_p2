using ConfirmCoords.Domain.ViewModels;

namespace ConfirmCoords.App.Services
{
    public interface ICoordService
    {
        Task<CreatingCoordResultViewModel> CreateCoord(CreatingCoordViewModel request);
    }
}
