using ConfirmCoords.Domain.Models;

namespace ConfirmCoords.App.Queries.GetCoord
{
    public record GetCoordQueryResult(CoordDetails result, string? ErrorMessage = null);
   
}
