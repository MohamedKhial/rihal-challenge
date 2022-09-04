using MediatR;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Exceptions;
using rihal.challenge.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Features.Classes.Queries.GetByIdClass
{
    public class GetByIdClassQueryHandler : IRequestHandler<GetByIdClassQuery, Class>
    {
        private IClassRepo _classRepo;

        public GetByIdClassQueryHandler(IClassRepo classRepo)
        {
            _classRepo = classRepo;
        }
        public async Task<Class> Handle(GetByIdClassQuery request, CancellationToken cancellationToken)
        {
            var GetByIdItem = await _classRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (GetByIdItem == null)
            {
                throw new NotFoundException("Class Is Null");
            }
            return GetByIdItem;
        }
    }
}
