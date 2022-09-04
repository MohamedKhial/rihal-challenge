using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using rihal.challenge.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Countries.Queries.GetByIdCountry
{
    public class GetByIdCountryQueryHandler : IRequestHandler<GetByIdCountryQuery, Country>
    {
        private ICountryRepo _countryRepo;

        public GetByIdCountryQueryHandler(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }
        public async Task<Country> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
        {
            var GetByIdItem = await _countryRepo.FirstOrDefaultAsync(x => x.Id == request.Id);


            if (GetByIdItem == null)
            {
                throw new NotFoundException("country Is Null");
            }
            return GetByIdItem;
        }
    }
}
