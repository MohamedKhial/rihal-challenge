

using FluentValidation;

namespace rihal.challenge.Application.Features.Classes.Queries.GetByIdClass
{
    public class GetByIdClassQueryValidator : AbstractValidator<GetByIdClassQuery>
    {
        public GetByIdClassQueryValidator()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");

               
        }
    }
}





