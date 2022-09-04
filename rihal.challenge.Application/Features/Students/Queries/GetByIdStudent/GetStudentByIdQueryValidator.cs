

using FluentValidation;

namespace rihal.challenge.Application.Features.Students.Queries.GetByIdStudent
{
    public class GetStudentByIdQueryValidator : AbstractValidator<GetByIdStudentQuery>
    {
        public GetStudentByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");

               
        }
    }
}





