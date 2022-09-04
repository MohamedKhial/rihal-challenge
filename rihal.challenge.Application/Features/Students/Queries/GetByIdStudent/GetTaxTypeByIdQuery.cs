using MediatR;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Features.Students.Queries.GetByIdStudent
{
    public class GetByIdStudentQuery : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
