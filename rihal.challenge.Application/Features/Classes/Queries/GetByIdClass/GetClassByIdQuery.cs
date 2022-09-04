using MediatR;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Features.Classes.Queries.GetByIdClass
{
    public class GetByIdClassQuery : IRequest<Class>
    {
        public int Id { get; set; }
    }
}
