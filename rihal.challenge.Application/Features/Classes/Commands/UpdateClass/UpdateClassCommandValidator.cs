using FluentValidation;

namespace rihal.challenge.Application.Features.Classes.Commands.UpdateClass
{
    public class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
    {
        public UpdateClassCommandValidator()
        {
            RuleFor(x => x.Model.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");

        }
    }
}





