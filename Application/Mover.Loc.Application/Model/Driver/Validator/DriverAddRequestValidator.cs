using FluentValidation;
using Mover.Loc.Application.Model.Driver.Request;

namespace Mover.Loc.Application.Model.Driver.Validator
{
    public class DriverAddRequestValidator : AbstractValidator<DriverAddRequest>
    {
        public DriverAddRequestValidator()
        {
            RuleFor(x=> x.Cnpj)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cnpj is required");

            RuleFor(x=> x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required");


            RuleFor(x=> x.NumberCnh)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cnh Number is required");

            RuleFor(x=> x.CnhType)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cnh Type is required")
                .Custom((value, context) => {
                    if(value != "A" && value != "B" && value != "AB")
                    {
                        context.AddFailure(new FluentValidation.Results.ValidationFailure("Cnh Type", "Cnh Type Invalid (A, B or AB)"));
                    }
                });

        }
    }
}