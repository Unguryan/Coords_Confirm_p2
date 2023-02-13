using ConfirmCoords.Domain.Models;
using ConfirmCoords.Domain.ViewModels;

namespace ConfirmCoords.App.Services
{
    public interface ICoordRepository
    {
        Task<CoordDetails> GetCoordDetails(int id);

        Task<CoordDetails> AddCoordDetails(CreatingCoordViewModel coordDetails);

        //Task<CoordDetails> RemoveCoordDetails(int id);

        //Task<bool> SaveChangesAsync();
    }
}
