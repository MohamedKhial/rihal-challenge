using FluentValidation;

namespace rihal.challenge.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(x => x.Model.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");

        }
    }
}





