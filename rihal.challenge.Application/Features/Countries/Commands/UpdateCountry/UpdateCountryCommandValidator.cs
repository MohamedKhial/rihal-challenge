using FluentValidation;

namespace rihal.challenge.Application.Features.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(x => x.Model.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");

        }
    }
}





