using AutoMapper;
using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepo _countryRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryCommandHandler(IMapper mapper, ICountryRepo countryRepo, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _countryRepo = countryRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<Country>(request.Model);
            _countryRepo.Add(entityToCreate);
            await _unitOfWork.SaveChangesAsync();
            return entityToCreate;
        }
    }
}


