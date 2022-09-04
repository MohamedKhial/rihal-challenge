using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Classes.Commands.DeleteClass
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, bool>
    {
        private readonly IClassRepo _classRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClassCommandHandler(IClassRepo classRepo, IUnitOfWork unitOfWork)
        {
            _classRepo = classRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _classRepo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"Entity not found for delete action");
            }
           

            _classRepo.Delete(entityToDelete);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

