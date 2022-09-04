using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentCommandHandler(IStudentRepo studentRepo, IUnitOfWork unitOfWork)
        {
            _studentRepo = studentRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _studentRepo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"Entity not found for delete action");
            }
           

            _studentRepo.Delete(entityToDelete);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

