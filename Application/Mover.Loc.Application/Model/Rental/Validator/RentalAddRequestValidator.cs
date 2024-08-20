using FluentValidation;
using Mover.Loc.Application.Model.Rental.Request;

namespace Mover.Loc.Application.Model.Rental.Validator
{
    public class RentalAddRequestValidator : AbstractValidator<RentalAddRequest>
    {
        public RentalAddRequestValidator()
        {
            RuleFor(x=> x.DtStart)
                .NotEmpty()
                .NotNull()
                .WithMessage("Date Start is required")
                .Custom((value, context) => {
                    if(value < DateTime.Now)
                    {
                        context.AddFailure(new FluentValidation.Results.ValidationFailure("Date Start", "Date Start is invalid"));
                    }
                });

            RuleFor(x=> x.DtEnd)
                .NotEmpty()
                .NotNull()
                .WithMessage("Date End is required");

            RuleFor(x=> x.EstimatedEndDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Estimated End Date is required");
        }
    }
}