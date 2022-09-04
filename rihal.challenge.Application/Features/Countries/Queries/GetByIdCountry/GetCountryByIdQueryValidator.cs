

using FluentValidation;

namespace rihal.challenge.Application.Features.Countries.Queries.GetByIdCountry
{
    public class GetCountryByIdQueryValidator : AbstractValidator<GetByIdCountryQuery>
    {
        public GetCountryByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                    .NotNull().WithMessage("Id is required")
                    .NotEmpty().WithMessage("Id is required");

               
        }
    }
}





