using AutoMapper;
using ConfirmCoords.App.Services;
using MediatR;

namespace ConfirmCoords.App.Commands.CreateCoord
{
    public class CreateCoordCommandHandler : IRequestHandler<CreatingCoordCommand, CreatingCoordCommandResult>
    {
        private readonly ICoordService _coordService;
        private readonly IMapper _mapper;

        public CreateCoordCommandHandler(ICoordService coordService, IMapper mapper)
        {
            _coordService = coordService;
            _mapper = mapper;
        }

        public async Task<CreatingCoordCommandResult> Handle(CreatingCoordCommand request, CancellationToken cancellationToken)
        {
            var result = await _coordService.CreateCoord(request.Coord);

            return _mapper.Map<CreatingCoordCommandResult>(result);
        }
    }
}
