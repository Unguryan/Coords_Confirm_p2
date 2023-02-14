using AutoMapper;
using ConfirmCoords.App.Services;
using ConfirmCoords.Domain.ViewModels;
using FluentValidation;

namespace ConfirmCoords.Infrastructure.Services
{
    public class CoordService : ICoordService
    {
        private readonly ICoordRepository _repository;

        public CoordService(ICoordRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreatingCoordResultViewModel> CreateCoord(CreatingCoordViewModel request)
        {
            var result = await _repository.AddCoordDetails(request);

            return new CreatingCoordResultViewModel(true, result.Id);
        }
    }
}
