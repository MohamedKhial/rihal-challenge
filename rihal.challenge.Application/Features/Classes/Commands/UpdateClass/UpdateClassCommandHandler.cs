using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Classes.Commands.UpdateClass
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, bool>
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClassCommandHandler(IStudentRepo studentRepo, IUnitOfWork unitOfWork)
        {
            _studentRepo = studentRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;
            var entityToUpdate = await _studentRepo.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (entityToUpdate == null)
            {
                throw new NotFoundException($"Entity not found for update action");
            }

            //entityToUpdate.Id = model.Id;
            //entityToUpdate.TaxName = model.;
            //entityToUpdate.TaxNativeName = model.TaxNativeName;
            //entityToUpdate.Value = model.Value;

            _studentRepo.Update(entityToUpdate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
