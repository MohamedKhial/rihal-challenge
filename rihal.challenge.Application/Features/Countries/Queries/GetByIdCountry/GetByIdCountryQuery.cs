using MediatR;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Features.Countries.Queries.GetByIdCountry
{
    public class GetByIdCountryQuery : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
