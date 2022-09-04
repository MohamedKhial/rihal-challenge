using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
    {
        private readonly ICountryRepo _countryRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(ICountryRepo countryRepo, IUnitOfWork unitOfWork)
        {
            _countryRepo = countryRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _countryRepo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"Entity not found for delete action");
            }
           

            _countryRepo.Delete(entityToDelete);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

