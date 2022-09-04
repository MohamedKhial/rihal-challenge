using AutoMapper;
using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepo _studentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(IMapper mapper, IStudentRepo studentRepo, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _studentRepo = studentRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entityToCreate = _mapper.Map<Student>(request.Model);
            _studentRepo.Add(entityToCreate);
            await _unitOfWork.SaveChangesAsync();
            return entityToCreate;
        }
    }
}


