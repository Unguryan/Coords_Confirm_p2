using ConfirmCoords.App.Queries.GetCoord;
using ConfirmCoords.Domain.Errors;
using FluentValidation;

namespace ConfirmCoords.App.Validators
{
    public class GetCoordQueryValidator : AbstractValidator<GetCoordQuery>
    {
        public GetCoordQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(GetCoordErrors.IdRequired)
                .GreaterThanOrEqualTo(0).WithMessage(GetCoordErrors.IdNegative);
        }
    }
}
