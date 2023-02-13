using MediatR;

namespace ConfirmCoords.App.Queries.GetCoord
{
    public record GetCoordQuery(int Id) : IRequest<GetCoordQueryResult>;
}
