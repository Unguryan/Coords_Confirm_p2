using ConfirmCoords.Domain.Errors;
using ConfirmCoords.Domain.ViewModels;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ConfirmCoords.App.Validators
{
    public class CreatingCoordValidator : AbstractValidator<CreatingCoordViewModel>
    {
        public CreatingCoordValidator()
        {
            RuleFor(x => x.Details)
                .NotEmpty().WithMessage(CreatingCoordErrors.DetailsRequired);

            RuleFor(x => x.Latitude)
                .NotEmpty()
                .NotNull().WithMessage(CreatingCoordErrors.LatitudeRequired);

            RuleFor(x => x.Longitude)
                .NotEmpty()
                .NotNull().WithMessage(CreatingCoordErrors.LongitudeRequired);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull().WithMessage(CreatingCoordErrors.PhoneNumberRequired)
                .Length(13).WithMessage(CreatingCoordErrors.PhoneNumberLength)
                .Matches(new Regex(@"\d{3}-\d{3}-\d{2}-\d{2}$")).WithMessage(CreatingCoordErrors.PhoneNumberInvalid);
        }
    }
}
