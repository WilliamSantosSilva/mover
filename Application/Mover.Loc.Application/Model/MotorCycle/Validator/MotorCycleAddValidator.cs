using FluentValidation;
using Mover.Loc.Application.Model.MotorCycle.Request;

namespace Mover.Loc.Application.Model.MotorCycle.Validator
{
    public class MotorCycleAddValidator : AbstractValidator<MotorCycleAdd>
    {
        public MotorCycleAddValidator()
        {
            RuleFor(x=> x.Model)
                .NotEmpty()
                .NotNull()
                .WithMessage("Model is required");

            RuleFor(x=> x.Year)
                .NotNull()
                .NotEqual(0)
                .WithMessage("Year is required");

            RuleFor(x=> x.Plate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Plate is required");
        }
    }
}