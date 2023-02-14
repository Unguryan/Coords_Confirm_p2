using AutoMapper;
using ConfirmCoords.App.Services;
using ConfirmCoords.Domain.ViewModels;
using FluentValidation;
using MediatR;

namespace ConfirmCoords.App.Commands.CreateCoord
{
    public class CreateCoordCommandHandler : IRequestHandler<CreatingCoordCommand, CreatingCoordCommandResult>
    {
        private readonly ICoordService _coordService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreatingCoordViewModel> _validator;

        public CreateCoordCommandHandler(ICoordService coordService,
                                         IMapper mapper,
                                         IValidator<CreatingCoordViewModel> validator)
        {
            _coordService = coordService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreatingCoordCommandResult> Handle(CreatingCoordCommand request, CancellationToken cancellationToken)
        {
            var validateRes = await _validator.ValidateAsync(request.Coord);

            if (!validateRes.IsValid)
            {
                var errorsStr = string.Empty;
                validateRes.Errors.ForEach(e => errorsStr += $"{e}\n");
                return new CreatingCoordCommandResult(false, null, errorsStr);
            }


            var result = await _coordService.CreateCoord(request.Coord);

            return _mapper.Map<CreatingCoordCommandResult>(result);
        }
    }
}
