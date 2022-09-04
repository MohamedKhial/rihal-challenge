using FluentValidation;

namespace rihal.challenge.Application.Features.Classes.Commands.DeleteClass
{
    public class DeleteClassCommandValidator : AbstractValidator<DeleteClassCommand>
    {
        public DeleteClassCommandValidator()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");
        }
    }
}



