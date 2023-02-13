using ConfirmCoords.App.Services;
using FluentValidation;
using MediatR;

namespace ConfirmCoords.App.Queries.GetCoord
{
    public class GetCoordQueryHandler : IRequestHandler<GetCoordQuery, GetCoordQueryResult>
    {
        private readonly ICoordRepository _coordRepository;
        private readonly IValidator<GetCoordQuery> _validator;

        public GetCoordQueryHandler(ICoordRepository coordRepository, IValidator<GetCoordQuery> validator)
        {
            _coordRepository = coordRepository;
            _validator = validator;
        }

        public async Task<GetCoordQueryResult> Handle(GetCoordQuery request, CancellationToken cancellationToken)
        {
            var validateRes = await _validator.ValidateAsync(request);

            if (!validateRes.IsValid)
            {
                var errorsStr = string.Empty;
                validateRes.Errors.ForEach(e => errorsStr += $"{e}\n");
                return new GetCoordQueryResult(null, errorsStr);
            }

            var result = await _coordRepository.GetCoordDetails(request.Id);

            return new GetCoordQueryResult(result);
        }
    }
}
