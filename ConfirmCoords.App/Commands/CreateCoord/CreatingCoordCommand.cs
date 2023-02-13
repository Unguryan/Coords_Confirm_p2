using ConfirmCoords.Domain.ViewModels;
using MediatR;

namespace ConfirmCoords.App.Commands.CreateCoord
{
    public record CreatingCoordCommand(CreatingCoordViewModel Coord) : IRequest<CreatingCoordCommandResult>;
}
