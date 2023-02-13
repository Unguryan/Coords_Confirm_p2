using AutoMapper;
using ConfirmCoords.App.Services;
using ConfirmCoords.Domain.ViewModels;
using FluentValidation;

namespace ConfirmCoords.Infrastructure.Services
{
    public class CoordService : ICoordService
    {
        private readonly ICoordRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreatingCoordViewModel> _validator;

        public CoordService(ICoordRepository repository,
                            IMapper mapper,
                            IValidator<CreatingCoordViewModel> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreatingCoordResultViewModel> CreateCoord(CreatingCoordViewModel request)
        {
            var validateRes = await _validator.ValidateAsync(request);

            if (!validateRes.IsValid)
            {
                var errorsStr = string.Empty;
                validateRes.Errors.ForEach(e => errorsStr += $"{e}\n");
                return new CreatingCoordResultViewModel(false, null, errorsStr);
            }

            var result = await _repository.AddCoordDetails(request);

            return new CreatingCoordResultViewModel(true, result.Id);
        }
    }
}
