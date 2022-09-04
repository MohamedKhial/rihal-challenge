using MediatR;

namespace rihal.challenge.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
