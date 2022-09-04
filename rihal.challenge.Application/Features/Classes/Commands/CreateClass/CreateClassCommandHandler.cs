using AutoMapper;
using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Classes.Commands.CreateClass
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, Class>
    {
        private readonly IMapper _mapper;
        private readonly IClassRepo _classRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClassCommandHandler(IMapper mapper, IClassRepo classRepo, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _classRepo = classRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Class> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<Class>(request.Model);
            _classRepo.Add(entityToCreate);
            await _unitOfWork.SaveChangesAsync();
            return entityToCreate;
        }
    }
}


