using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using rihal.challenge.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Students.Queries.GetByIdStudent
{
    public class GetByIdStudentQueryHandler : IRequestHandler<GetByIdStudentQuery, Student>
    {
        private IStudentRepo _studentRepo;

        public GetByIdStudentQueryHandler(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public async Task<Student> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
        {
            var GetByIdItem = await _studentRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (GetByIdItem == null)
            {
                throw new NotFoundException("Student Is Null");
            }
            return GetByIdItem;
        }
    }
}
