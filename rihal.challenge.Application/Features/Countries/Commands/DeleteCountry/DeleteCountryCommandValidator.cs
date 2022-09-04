using FluentValidation;

namespace rihal.challenge.Application.Features.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");
        }
    }
}



