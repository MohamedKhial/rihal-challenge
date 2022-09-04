using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, bool>
    {
        private readonly ICountryRepo _countryRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryCommandHandler(ICountryRepo countryRepo, IUnitOfWork unitOfWork)
        {
            _countryRepo = countryRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;
            var entityToUpdate = await _countryRepo.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entityToUpdate == null)
            {
                throw new NotFoundException($"Entity not found for update action");
            }

            //entityToUpdate.Id = model.Id;
            //entityToUpdate.TaxName = model.;
            //entityToUpdate.TaxNativeName = model.TaxNativeName;
            //entityToUpdate.Value = model.Value;

            _countryRepo.Update(entityToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
